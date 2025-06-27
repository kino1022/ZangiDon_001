using Sirenix.OdinInspector;
using UnityEngine;

namespace Teiwas.Script.Bullet.Data {
    [CreateAssetMenu(menuName = "Project/Bullet/BulletData")]
    public class BulletData : SerializedScriptableObject {
        
        [SerializeField, LabelText("生成物"),Title("生成物")]
        public GameObject Prefab;
        
    }
}