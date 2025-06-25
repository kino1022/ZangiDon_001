using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Asset.Status.Health.Interface;
using UnityCommonModule.Status;
using UnityCommonModule.Status.Asset;
using UnityCommonModule.Status.Module.Calculator;
using UnityEngine;
using UnityEngine.Events;

namespace Teiwas.Script.Asset.Status.Health {
    public class Health : AStatus<int,IntCalculator>, IHealth {
        
        [OdinSerialize, SerializeField, LabelText("最大体力管理コンポーネント")]
        protected IMaxHealth m_max;

        [OdinSerialize, SerializeField, LabelText("回復制御モジュール")]
        protected HealModule m_healModule;
        
        public IHealable Heal => m_healModule;
        
        [OdinSerialize, SerializeField, LabelText("ダメージ制御モジュール")]
        protected DamageModule m_damageModule;
        
        public IDamageable Damage => m_damageModule;

        public UnityEvent<GameObject> DeathUEvent { get; set; }

        private void Awake() {
            m_max = GetComponent<IMaxHealth>();

            if (m_max != null){
                Debug.LogError("IMaxHealthを継承したコンポーネントがアタッチされていません");
                return;
            }

            m_healModule = new HealModule(this, this.gameObject);
            m_damageModule = new DamageModule(this, this.gameObject);
        }

        protected override void OnPostValueChange() {
            base.OnPostValueChange();

            if (Raw.Get() > m_max.Get()) {
                Debug.Log("体力が最大体力を上回ったため、体力を最大体力で初期化します");
                Raw.Set(m_max.Get());
            }
            
        }
    }
}