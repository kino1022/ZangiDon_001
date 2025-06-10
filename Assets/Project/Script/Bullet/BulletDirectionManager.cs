using System;
using Project.Script.Bullet.Homing;
using Project.Script.Bullet.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.CharacterMove.Interface;
using UnityCommonModule.Target.Interface;
using UnityEngine;

namespace Project.Script.Bullet {
    [Serializable]
    public class BulletDirectionManager : SerializedMonoBehaviour {

        [OdinSerialize] protected HomingDirectionModule m_homingModule;

        [OdinSerialize] protected ITargetHolder<GameObject> m_target;

        [OdinSerialize] protected IBulletDataHolder m_data;
        
        
    }
}