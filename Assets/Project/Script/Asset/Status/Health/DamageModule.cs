using System;
using Project.Script.Asset.Status.Health.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Correction;
using UnityCommonModule.Correction.Interface;
using UnityCommonModule.Status;
using UnityCommonModule.Status.Module.Calculator;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Script.Asset.Status.Health {
    [Serializable]
    public class DamageModule : IDamageable {
        
        protected IHealth m_health;

        protected ICorrector m_corrector = new CorrectionManager();
        
        public UnityEvent<GameObject,int> DamageUEvent; 

        public DamageModule(IHealth health) {
            m_health = health;
        }

        public void Damage(int amount) {
            throw new NotImplementedException();
        }

        public void InstantDamage(int amount) {
            
        }
        

        public void AddCorrection(ICorrection correction) {
            throw new NotImplementedException();
        }

        public void RemoveCorrection(ICorrection target) {
            
        }
    }
}