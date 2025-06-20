using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Asset.Status.Health.Interface;
using UnityCommonModule.Correction;
using UnityCommonModule.Correction.Interface;
using UnityCommonModule.Status;
using UnityCommonModule.Status.Module.Calculator;
using UnityEngine;
using UnityEngine.Events;

namespace Teiwas.Script.Asset.Status.Health {
    [Serializable]
    public class DamageModule : IDamageable {
        
        protected IHealth m_health;

        protected ICorrector m_corrector = new CorrectionManager();

        protected GameObject m_character;
        
        public UnityEvent<GameObject,int> DamageUEvent; 

        public DamageModule(IHealth health,GameObject holder) {
            m_health = health;
            m_character = holder;
        }

        public void Damage(int amount) {
            var value = amount;

            value = (int)m_corrector.Execute(amount);

            m_health.Decrease(value);
            DamageUEvent?.Invoke(m_character, value);
        }

        public void InstantDamage(int amount) {
            m_health.Decrease(amount);
            DamageUEvent?.Invoke(m_character, amount);
        }
        

        public void AddCorrection(ICorrection correction) {
            m_corrector.Add(correction);
        }

        public void RemoveCorrection(ICorrection target) {
            m_corrector.Remove(target);
        }
    }
}