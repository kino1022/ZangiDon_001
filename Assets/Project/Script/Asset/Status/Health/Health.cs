using Project.Script.Status;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Script.Asset.Status.Health {
    [LabelText("現在の体力")]
    public class Health : StatusBase {

        public UnityEvent<GameObject, float> HealUEvent;
        
        public UnityEvent<GameObject, float> DamageUEvent;
        
        public UnityEvent<GameObject> DeathUEvent;

        #region API Methods
        
        /// <summary>
        /// 補正値などの計算を行ってから回復する
        /// </summary>
        /// <param name="amount"></param>
        public void Heal(float amount) {
            var healValue = amount;
            
            //補正値計算などの処理を挟む
            
            Increase(healValue);
            HealUEvent?.Invoke(this.gameObject,healValue);
        }
        
        /// <summary>
        /// 補正値などの計算を行ったダメージを受ける
        /// </summary>
        /// <param name="amount"></param>
        public void Damage(float amount) {
            var damageValue = amount;
            
            //補正値計算などの処理を挟む
            
            Increase(damageValue);
            DamageUEvent?.Invoke(this.gameObject, damageValue);
        }
        
        /// <summary>
        /// 補正を一切考慮しない固定値の回復を行う
        /// </summary>
        /// <param name="amount"></param>
        public void InstantHeal(float amount) {
            Increase(amount);
            HealUEvent?.Invoke(this.gameObject, amount);
        }

        /// <summary>
        /// 補正を一切考慮しない固定値のダメージを受ける
        /// </summary>
        /// <param name="amount"></param>
        public void InstantDamage(float amount) {
            Increase(amount);
            DamageUEvent?.Invoke(this.gameObject, amount);
        }
        
        #endregion
        
        #region Hook Point

        protected override void OnValueChange(float value) {
            if (value <= 0.0f) {
                DeathUEvent?.Invoke(this.gameObject);
                return;
            }
            base.OnValueChange(value);
        }

        #endregion
    }
}