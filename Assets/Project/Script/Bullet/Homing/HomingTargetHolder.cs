using System;
using Project.Script.Bullet.Homing.Interface;
using Project.Script.Bullet.Target.Interface;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Bullet.Homing {
    [Serializable]
    public class HomingTargetHolder : IHomingTargetHolder {
        
        [OdinSerialize]
        protected IBulletTargetHolder m_bulletTarget;


        public GameObject GetTarget() {
            return m_bulletTarget.GetTarget();
        }
    }
}