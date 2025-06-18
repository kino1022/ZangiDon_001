using Project.Script.Asset.Status.Health.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Status;
using UnityCommonModule.Status.Asset;
using UnityCommonModule.Status.Module.Calculator;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Script.Asset.Status.Health {
    public class Health : AStatus<int,IntCalculator>, IHealth {
        
        [OdinSerialize, SerializeField, LabelText("最大体力管理コンポーネント")]
        protected IntCorrectableStatus m_maxHealth;

        [OdinSerialize, SerializeField, LabelText("回復制御モジュール")]
        protected HealModule m_healModule;
        
        public IHealable Heal => m_healModule;
        
        
        [OdinSerialize, SerializeField, LabelText("ダメージ制御モジュール")]
        protected DamageModule m_damageModule;
        
        public IDamageable Damage=> m_damageModule;

        public UnityEvent<GameObject> DeathUEvent;

        private void Awake() {

        }
        
        
    }
}