using System;
using MessagePipe;
using Mono.Cecil.Cil;
using Project.Script.Utility;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Motion.State.Context;
using Teiwas.Script.Motion.State.Context.Interface;
using UnityEngine;
using VContainer.Unity;

namespace Teiwas.Script.Motion.State {
    public class MotionStateController : SerializedStateMachineBehaviour {

        [OdinSerialize, Title("自由落下制御コンテキスト")]
        protected IInMotionFreeFallContext m_fallable = new InMotionFreeFallContext();

        /// <summary>
        /// 現在落下可能かどうか
        /// </summary>
        /// <typeparam name="bool"></typeparam>
        /// <returns></returns>
        public ReactiveProperty<bool> Fallable => new ReactiveProperty<bool>(m_fallable.Fallable);

        [OdinSerialize, Title("モーションキャンセル制御コンテキスト")]
        protected ICancelMotionContext m_cancelable = new CancelMotionContext();

        protected IPublisher<>

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

            base.OnStateEnter(animator, stateInfo, layerIndex);

            var container = ComponentsUtility.GetComponentFromWhole<LifetimeScope>(animator.gameObject);

            if(container is null) {
                Debug.LogError($"{animator.gameObject.name}にはLifetimeScopeを継承したクラスがアタッチされていませんでした");
                throw new SymbolsNotFoundException(nameof(LifetimeScope));
            }


        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            base.OnStateUpdate(animator, stateInfo, layerIndex);

            var currentClipInfo = animator.GetCurrentAnimatorClipInfo(layerIndex);
            var currentStateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);

            //ブレンド中でモーションが複数存在するかどうかの検知
            if(currentClipInfo.Length > 1) {
                Debug.Log($"{animator.name}がブレンド中のため複数のモーションが存在します");
            }

            //現在フレームの算出処理
            var currentFrame = CalculateCurrentFrame(currentClipInfo[0], currentStateInfo);

            m_fallable?.Update(currentFrame);

            m_cancelable?.Update(currentFrame);
        }

        protected int CalculateCurrentFrame(AnimatorClipInfo clip, AnimatorStateInfo state) {

            var total = clip.clip.length * clip.clip.frameRate;

            var current = state.normalizedTime % 1.0f;

            return Mathf.FloorToInt(total * current);
        }

        public bool Cancelable(AnimationClip motion) {

            if(motion is null) {
                throw new ArgumentNullException(nameof(motion));
            }

            if(m_cancelable is null) {
                throw new NullReferenceException();
            }

            return m_cancelable.Cancelable(motion);
        }
    }
}
