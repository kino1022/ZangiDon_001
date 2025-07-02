using System;
using Project.Script.LockManage;
using R3;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Script.Bullet.Movement.Direction.Pattern {
    /// <summary>
    /// 直線運動を表現する動作パターン
    /// </summary>
    [Serializable]
    public class StraightPattern : IDirectionPattern {
        
        [SerializeField, LabelText("移動方向")]
        protected Vector3 m_direction;
        public Vector3 Direction => m_direction;

        protected ILockTargetHolder m_target;

        protected GameObject m_self;

        public void StartControl(IObjectResolver resolver, GameObject self) {
            
            m_target = resolver.Resolve<ILockTargetHolder>();
            m_self = self;

            if (m_target.GetTarget() == null) {
                m_direction = m_self.transform.forward;
                return;
            }
            
            var dir = 
                m_target.GetTarget().transform.position - m_self.transform.position;
            
            m_direction = dir.normalized;
        }
        
    }
}