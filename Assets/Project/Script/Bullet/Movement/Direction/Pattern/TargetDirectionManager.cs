using System;
using System.Runtime.Serialization;
using Project.Script.LockManage;
using Sirenix.OdinInspector;
using Teiwas.Script.Bullet.Movement.Direction.Interface;
using Teiwas.Script.Bullet.Movement.Direction.Pattern;
using UnityEngine;
using VContainer;

namespace Teiwas.Script.Bullet.Movement.Direction {
    [Serializable]
    public class TargetDirectionManager : IDirectionPattern {
        [SerializeField]
        protected Vector3 m_direction = Vector3.zero;

        public Vector3 Direction => m_direction;

        protected GameObject m_target;

        protected GameObject m_bullet;

        public void StartControl(IObjectResolver resolver, GameObject self) {
            m_target = resolver.Resolve<ILockTargetHolder>().GetTarget();
            m_bullet = self;

            m_direction = (m_target.transform.position - m_bullet.transform.position).normalized;
        }
    }
}
