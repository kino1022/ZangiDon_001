using System;
using Project.Script.Bullet.Homing.Interface;
using Project.Script.Bullet.Interface;
using Sirenix.Serialization;
using UnityEngine;
using VContainer;

namespace Project.Script.Bullet.Homing {
    [Serializable]
    public class OnInitializeHomingModule : IHomingExecutor {
        
        [OdinSerialize] protected IBulletDataHolder m_data;
        
        [OdinSerialize] protected IHomingTargetHolder m_target;
        
        [Inject]
        public OnInitializeHomingModule(IBulletDataHolder dataholder,IHomingTargetHolder targetHolder) {
            m_data = dataholder;
            m_target = targetHolder;
        }

        public Vector3 ExecuteHoming(Vector3 position) {
            return Vector3.zero;
        }
    }
}