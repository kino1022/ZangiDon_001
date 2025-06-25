using System.Collections.Generic;
using Project.Script.Bullet.Components.Interface;
using Project.Script.Utility;
using Sirenix.OdinInspector;
using Teiwas.Script.Asset.Status.Health.Interface;
using UnityEngine;

namespace Project.Script.Bullet.Components {
    /// <summary>
    /// 当たった対象に対してダメージを与えるクラス
    /// </summary>
    public class CollisionExecutor : SerializedMonoBehaviour {
        
        protected IDamageHolder m_damage;
        
        
        private void Start() {
            
            m_damage = ComponentsUtility.GetComponentFromWhole<IDamageHolder>(this.gameObject);
            
        }

        public void OnTriggerEnter(Collider other) {
            
            //ダメージ処理
            var damage = ComponentsUtility.GetComponentFromWhole<IDamageable>(other.gameObject);
            
            if (damage != null) {
                damage.Damage(m_damage.GetDamage());
            }
            else {
                Debug.Log("衝突した対象にIDamageableを継承したコンポーネントの定義がありませんでした");
            }
            
            
        }
    }
}