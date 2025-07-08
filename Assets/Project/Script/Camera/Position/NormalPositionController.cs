using System;
using Cysharp.Threading.Tasks;
using Project.Script.LockManage;
using Project.Script.Utility;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Camera.Position.Interface;
using Teiwas.Script.UIControl.Utility;
using UnityEngine;
using VContainer;

namespace Teiwas.Script.Camera.Position {
    [Serializable]
    public class NormalPositionController : ICameraPositionHolder , IDisposable {

        [OdinSerialize, LabelText("オフセット")] 
        protected ICameraOffSetHolder m_offset;
        
        [SerializeField, LabelText("カメラポジション")]
        protected Vector3 m_position = Vector3.zero;
        
        protected ILockTargetHolder m_targetHolder;
        
        [OdinSerialize, ReadOnly]
        protected GameObject m_target;

        [OdinSerialize, ReadOnly] 
        protected GameObject m_player;
        
        public ICameraOffSetHolder OffSet => m_offset;
        public Vector3 Position => m_position;
        
        protected CompositeDisposable m_changeTargetDisposable = new CompositeDisposable();
        protected CompositeDisposable m_targetTransformDisposable = new CompositeDisposable();
        protected CompositeDisposable m_playerTransformDisposable = new CompositeDisposable();

        public void Dispose() {
            m_changeTargetDisposable.Dispose();
            m_targetTransformDisposable.Dispose();
            m_playerTransformDisposable.Dispose();
        }
        
        public void ControlStart(IObjectResolver resolver, GameObject camera) {
            
            m_targetHolder = resolver.Resolve<ILockTargetHolder>();
            m_player = ComponentsUtility.GetComponentFromWhole<PlayerCharacterHolder>(camera).GetTarget();

            if (m_player == null) {
                Debug.LogError($"{this.GetType().Name}でplayerを取得できませんでした");
                return;
            }
            
            m_playerTransformDisposable = new CompositeDisposable();
            //プレイヤーの座標変化の購読処理
            ObserveTransform(m_player,m_playerTransformDisposable);
            
            m_targetTransformDisposable = new CompositeDisposable();
            
            ObserveOffset();
        }

        protected void ObserveChangeTarget() {
            Observable
                .EveryValueChanged(m_targetHolder, x => x.GetTarget())
                .Subscribe(x => {
                    Debug.Log($"{this.GetType().Name}で{m_player.name}の{x.name}へのターゲット変化を検知しました");
                    OnTargetChanged(x);
                })
                .AddTo(m_changeTargetDisposable);
        }

        protected virtual void OnTargetChanged(GameObject x) {
            //既存のターゲット座標変化の監視処理を開放
            m_targetTransformDisposable.Dispose();
            //初期化
            m_targetTransformDisposable = new CompositeDisposable();
            m_target = x;
            if (m_target != null) {
                //新規のターゲット座標変化の購読処理
                ObserveTransform(x,m_targetTransformDisposable);
            }
        }
        
        /// <summary>
        /// 渡されたゲームオブジェクトの座標変化を監視するメソッド
        /// </summary>
        /// <param name="x">監視するゲームオブジェクト</param>
        /// <param name="disposable">利用するCompositeDisposable</param>
        protected void ObserveTransform(GameObject x,CompositeDisposable disposable) {
            
            Observable
                .EveryValueChanged(x, go => go.transform.position)
                .Subscribe(go => {
                    Debug.Log($"{x.name}の座標変化を検知しました");
                    OnTransformChanged();
                })
                .AddTo(disposable);
        }

        protected void ObserveOffset() {
            
            Observable
                .EveryValueChanged(m_offset, x => x.Distance)
                .Subscribe(x => {
                    Debug.Log($"{m_offset.GetType().Name}のDistanceの変化を検知しました");
                    UpdatePosition();
                })
                .AddTo(m_player.GetCancellationTokenOnDestroy());
            
            Observable
                .EveryValueChanged(m_offset, x => x.Height)
                .Subscribe(x => {
                    Debug.Log($"{m_offset.GetType().Name}のHeightの変化を検知しました");
                    UpdatePosition();
                })
                .AddTo(m_player.GetCancellationTokenOnDestroy());
        }

        protected virtual void OnTransformChanged() {
            UpdatePosition();
        }

        protected virtual void UpdatePosition() {
            m_position = new NormalPositionCalculator(m_player, m_target, m_offset).Calculate();
        }
    }
}