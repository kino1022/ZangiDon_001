using System;
using Project.Script.Asset.Status.Health.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Correction;
using UnityCommonModule.Correction.Interface;
using UnityCommonModule.Status;
using UnityCommonModule.Status.Asset;
using UnityCommonModule.Status.Module.Calculator;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Script.Asset.Status.Health {
    [Serializable]
    public class HealModule : IHealable {

        protected IHealth m_health;
        
        protected ICorrector m_correction = new CorrectionManager();

        public UnityEvent<GameObject, int> HealUEvent { get; set; }

        public HealModule(IHealth health) {
            m_health = health;
        }

        public void Heal(int amount) {
            var value = amount;

            value = (int) m_correction.Execute(amount);
            
            m_health.Increase(value);
        }

        public void InstantHeal(int amount) {
            m_health.Increase(amount);
        }

        public void AddCorrection(ICorrection correction) {
            m_correction.Add(correction);
        }

        public void RemoveCorrection(ICorrection target) {
            m_correction.Remove(target);
        }
    }
}