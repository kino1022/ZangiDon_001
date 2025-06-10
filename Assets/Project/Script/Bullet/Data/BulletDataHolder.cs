using Project.Script.Bullet.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Bullet.Data {
    
    public class BulletDataHolder : SerializedMonoBehaviour , IBulletDataHolder {
        
        [SerializeField,OdinSerialize,LabelText("弾丸のデータ")]
        protected BulletData bulletData;

        public BulletData GetBulletData() {
            return bulletData;
        }
    }
}