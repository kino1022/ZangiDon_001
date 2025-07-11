using System;
using System.Collections.Generic;
using Project.Script.LockManage;
using Project.Script.Utility;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Camera.Angle.Interface;
using Teiwas.Script.UIControl.Utility;
using UnityEngine;
using VContainer;

namespace Teiwas.Script.Camera.Angle {
    [Serializable]
    public class NormalAngleController : ICameraAngleHolder {

        [SerializeField, ReadOnly, LabelText("アングル")]
        protected Quaternion m_angle = Quaternion.identity;

        [SerializeField, ReadOnly, LabelText("キャラクター")]
        protected GameObject m_player;


        [OdinSerialize, LabelText("アングル制御")]
        protected List<ICameraAngleLimiter> m_limiters = new();

        [OdinSerialize, LabelText("ロック対象コンテキスト")]
        protected ITargetContextHolder m_context;

        protected GameObject m_camera;

        protected ILockTargetHolder m_targetHolder;

        public Quaternion Angle => m_angle;

        public void ControlStart(IObjectResolver resolver, GameObject camera) {
            m_targetHolder = resolver.Resolve<ILockTargetHolder>();
            m_camera = camera;
            m_player = ComponentsUtility.GetComponentFromWhole<PlayerCharacterHolder>(camera).GetTarget();
            m_context = resolver.Resolve<ITargetContextHolder>();

            if(m_context is null) {
                Debug.LogError("IObjectResolverからITargetContextHolderを取得できませんでした");
                return;
            }
            //ターゲット変化の監視処理
            ObserveChangeTarget();
            ///方向変化の購読処理
            ObservableDirection();
        }

        //アングルの更新に関わる要素を全て監視して、それを全てアングル更新メソッドに繋ぐ


        protected void UpdateAngle() {
            m_angle = CalculateAngle();
        }

        protected Quaternion CalculateAngle() {
            //アングル角の計算
            var result = new NormalAngleCalculater(m_camera, m_context.Context.Target, m_player).CalculateAngle();

            //アングル制限の適用処理
            if(m_limiters.Count != 0) {
                foreach(var limiter in m_limiters) {
                    result = Quaternion.Euler(limiter.ApplyLimit(result.eulerAngles));
                }
            }

            return result;
        }

        protected void ObserveChangeTarget() {

            if(m_context is null) {
                Debug.Log($"{GetType().Name}がIContextHolderを取得できていませんでした");
                return;
            }

            if(m_context.Context is null) {
                Debug.LogError($"{m_context.GetType().Name}のContext初期化処理が間に合っていませんでした");
                return;
            }

            Observable
                .EveryValueChanged(m_context, x => x?.Context?.Target)
                .Subscribe(x => {
                    if(x == null) {
                        return;
                    }
                    UpdateAngle();
                })
                .AddTo(m_player);
        }

        protected void ObservableDirection() {
            Observable
                .EveryValueChanged(m_context, x => x.Context.Direction)
                .Subscribe(x => {
                    UpdateAngle();
                })
                .AddTo(m_player);
        }
    }
}
