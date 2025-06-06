using Project.Script.Asset.Status.Health.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Unity.VisualScripting;
using UnityCommonModule.Status;
using UnityCommonModule.Status.Correctable;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Script.Asset.Status.Health {
    public class Health : IntStatus {
        
        [OdinSerialize, SerializeField, LabelText("最大体力管理コンポーネント")]
        protected IntCorrectableStatus m_maxHealth;

        [OdinSerialize, SerializeField, LabelText("回復制御モジュール")]
        protected HealModule m_healModule;
        
        public IHealable Healable => m_healModule;
        
        
        [OdinSerialize, SerializeField, LabelText("ダメージ制御モジュール")]
        protected DamageModule m_damageModule;
        
        public IDamageable Damageable => m_damageModule;

        public UnityEvent<GameObject> DeathUEvent;

        private void Awake() {
            m_healModule = new HealModule(this.gameObject,this);
            m_damageModule = new DamageModule(this.gameObject,this);
        }
        
        
        #region HookPoint

        protected override void OnPostValueChanged() {

            if (m_maxHealth.GetValue() < this.m_rawStatus.GetValue()) {
                m_rawStatus.SetValue(this.m_maxHealth.GetValue());
                return;
            }
            
            if (m_rawStatus.GetValue() <= 0) {
                DeathUEvent?.Invoke(this.gameObject);
                return;
            }
            
            base.OnPostValueChanged();
        }

        #endregion
        
    }
}