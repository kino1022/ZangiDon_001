using System;
using Project.Script.Asset.Status.Health.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Correction.Instant;
using UnityCommonModule.Status;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Script.Asset.Status.Health {
    [Serializable]
    public class DamageModule : IDamageable {
        [OdinSerialize]
        public UnityEvent<GameObject, int> DamageUEvent { get; set; }
        
        protected GameObject m_obj;
        
        protected AStatus<int> m_status;
        
        [OdinSerialize,SerializeField,LabelText("ダメージ補正値")]
        protected InstantCorrectionManager m_correction = new InstantCorrectionManager();

        public DamageModule(GameObject obj,AStatus<int> status) {
            m_obj = obj;
            m_status = status;
        }

        public void Damage(int amount) {
            var result = amount;
            
            result = (int) m_correction.ExecuteCorrection(amount);
            
            m_status.Increase(result);
            DamageUEvent?.Invoke(m_obj,result);
        }

        public void InstantDamage(int amount) {
            m_status.Increase(amount);
            DamageUEvent?.Invoke(m_obj,amount);
        }

        public void AddDamageCorrection(InstantCorrection correction) {
            m_correction.AddCorrection(correction);
        }

        public void RemoveDamageCorrection(InstantCorrection correction) {
            m_correction.RemoveCorrection(correction);
        }
    }
}