using System;
using UnityCommonModule.Correction.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Script.Status.Health {
    /// <summary>
    /// 現在の体力を管理するためのコンポーネント
    /// </summary>
    public class HealthPoint : StatusBase {
        
        [SerializeField] protected StatusBase m_maxHealth;

        [SerializeField] protected ICorrectionExecutor m_damageCorrection;
        
        [SerializeField] protected ICorrectionExecutor m_healCorrection;
        
        /// <summary>
        /// この人でなし！！
        /// </summary>
        public UnityEvent WasDeadUEvent;
        
        //-------------------------API methods----------------------------------
        
        /// <summary>
        /// 補正値を無視して体力を回復する
        /// </summary>
        /// <param name="amount"></param>
        public virtual void FixedHeal(float amount) { }
        
        /// <summary>
        /// 補正値を無視してダメージを受ける
        /// </summary>
        /// <param name="amount"></param>
        public virtual void FixedDamage (float amount) { }
        
        public virtual void Heal (float amount) {}
        
        public virtual void TakeDamage (float amount) {}
        
        //-------------------------Hook point------------------------------------

        protected override void OnValueChange(float value) {
            //最大体力を超過している場合は体力を最大値で上書きして処理を中断する
            if (m_maxHealth.GetValue() < value) {
                m_baseValue.Set(m_maxHealth.GetValue());
                return;
            }
            //体力が０ならイベントを発火して処理を中断する
            if (value <= 0.0f) {
                WasDeadUEvent?.Invoke();
                return;
            }
            base.OnValueChange(value);
        }
    }
}