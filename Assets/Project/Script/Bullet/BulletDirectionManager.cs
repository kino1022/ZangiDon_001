using System;
using Project.Script.Bullet.Homing;
using Project.Script.Bullet.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.CharacterMove.Homing.Interface;
using UnityCommonModule.CharacterMove.Interface;
using UnityCommonModule.Target.Interface;
using UnityEngine;
using VContainer;

namespace Project.Script.Bullet {
    /// <summary>
    /// 弾丸の進む方向を管理するクラス
    /// </summary>
    [Serializable]
    public class BulletDirectionManager : IDirectionHolder {

        [OdinSerialize] protected HomingDirectionModule m_homingModule;

        [OdinSerialize] protected OnInitializeHomingModule m_initHoming;

        [OdinSerialize] protected IBulletDataHolder m_data;
        
        [Inject]
        public BulletDirectionManager(HomingDirectionModule homingModule, OnInitializeHomingModule initHomingModule) {
            m_homingModule = homingModule;
            m_initHoming = initHomingModule;
        }

        public Vector3 GetDirection() {
            return Vector3.zero;
        }
    }
}