using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Asset.Status.Health.Interface;
using UnityCommonModule.Correction;
using UnityCommonModule.Correction.Interface;
using UnityCommonModule.Status;
using UnityCommonModule.Status.Asset;
using UnityCommonModule.Status.Module.Calculator;
using UnityEngine;
using UnityEngine.Events;

namespace Teiwas.Script.Asset.Status.Health {
    [Serializable]
    public class HealModule : IHealable {

        protected IHealth m_health;
        
        protected ICorrector m_correction = new CorrectionManager();
        
        protected GameObject m_chracter;

        public UnityEvent<GameObject, int> HealUEvent { get; set; }

        public HealModule(IHealth health,GameObject holder) {
            m_health = health;
            m_chracter = holder; 
        }

        public void Heal(int amount) {
            var value = amount;

            value = (int) m_correction.Execute(amount);
            
            m_health.Increase(value);
            HealUEvent?.Invoke(m_chracter, value);
        }

        public void InstantHeal(int amount) {
            m_health.Increase(amount);
            HealUEvent?.Invoke(m_chracter, amount);
        }

        public void AddCorrection(ICorrection correction) {
            m_correction.Add(correction);
        }

        public void RemoveCorrection(ICorrection target) {
            m_correction.Remove(target);
        }
    }
}