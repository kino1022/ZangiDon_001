using System;
using R3;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.LockManage {
    [Serializable]
    public class TargetContext : ITargetContext {
        [SerializeField]
        protected GameObject m_player;
        [SerializeField]
        protected GameObject m_target;
        [OdinSerialize]
        protected ILockTargetHolder m_holder;
        [SerializeField]
        protected float m_distance = 0.0f;
        [SerializeField]
        protected Vector3 m_direction = Vector3.zero;
        
        public GameObject Target => m_target;
        public float Distance => m_distance;
        public Vector3 Direction => m_direction;
        
        protected CompositeDisposable m_disposable = new CompositeDisposable();
        protected CompositeDisposable m_playerDisposeable  = new CompositeDisposable();
        protected CompositeDisposable m_targetDisposeable = new CompositeDisposable();

        public TargetContext(GameObject player, ILockTargetHolder holder) {
            m_player = player;
            if (m_player == null) {
                Debug.LogError("Playerのオブジェクトが取得できませんでした");
                return;
            }
            m_holder = holder;
            if (m_holder == null) {
                Debug.LogError("ILockTargetHolderを継承したオブジェクトが取得できませんでした");
                return;
            }
            
            RegisterHolder();
            
            RegisterPositionChange(m_player, m_playerDisposeable = new CompositeDisposable());
            UpdateContext();
        }

        public void Dispose() {
            m_disposable.Dispose();
        }


        protected void RegisterHolder() {
            Observable
                .EveryValueChanged(m_holder, x => x.GetTarget() != m_target)
                .Subscribe(x => {
                    Debug.Log($"{m_holder}の対象変化を検知したため、ターゲットの変数を変更しました");
                    m_target = m_holder?.GetTarget();
                    m_targetDisposeable?.Dispose();
                    RegisterPositionChange(m_target, m_targetDisposeable = new CompositeDisposable());
                })
                .AddTo(m_disposable);
        }

        protected void RegisterPositionChange(GameObject target, CompositeDisposable disposable) {
            
            if (target == null) {
                Debug.Log("座標監視の対象に指定されたオブジェクトがnullでした");
                disposable.Dispose();
                return;
            }

            if (disposable == null) {
                Debug.Log("CompositeDisposableがnullでした,座標監視処理を中断します");
                return;
            }
            
            Observable
                .EveryValueChanged(target, x => x.transform.position)
                .Subscribe(x => {
                    Debug.Log($"{target.name}の座標が変化しました");
                    UpdateContext();
                })
                .AddTo(disposable);
        }

        protected void UpdateContext() {
            UpdateDistance();
            UpdateDirection();
        }

        protected void UpdateDistance() {

            if (m_player == null) {
                Debug.LogError("Playerが存在していません");
                m_distance = 0.0f;
                return;
            }

            if (m_target == null) {
                m_distance = 0.0f;
                return;
            }
            
            m_distance = 
                Vector3.Distance(m_player.transform.position, m_target.transform.position);
        }

        protected void UpdateDirection() {

            if (m_player == null) {
                Debug.LogError("Playerが存在していません");
                m_direction = Vector3.zero;
                return;
            }

            if (m_target == null) {
                m_direction = Vector3.zero;
                return;
            }
            
            m_direction = 
                (m_player.transform.position - m_target.transform.position).normalized;
        }
    }
}