using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Bullet.Data {
    [Serializable]
    [CreateAssetMenu(menuName = "Project/Bullet/Data")]
    public class BulletData : SerializedScriptableObject {
        
        [SerializeField, OdinSerialize, Title("弾速")] public SpeedData speedData;

        [SerializeField, OdinSerialize, Title("生成時の誘導補正")] public HomingData initializeHoming;

        [SerializeField, OdinSerialize, Title("誘導")] public HomingData homingData;
    }
}