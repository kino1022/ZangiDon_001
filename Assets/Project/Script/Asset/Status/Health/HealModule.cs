using System;
using Project.Script.Asset.Status.Health.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Correction.Instant;
using UnityCommonModule.Status;
using UnityCommonModule.Status.Correctable;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Script.Asset.Status.Health {
    [Serializable]
    public class HealModule : IHealable {

        [OdinSerialize, SerializeField, LabelText("最大体力管理コンポーネント")]
        protected IntCorrectableStatus m_maxHealth;
        
        [OdinSerialize]
        public UnityEvent<GameObject,int> HealUEvent { get; set; }

        protected GameObject m_obj;

        protected AStatus<int> m_status;
        
        [OdinSerialize, SerializeField, LabelText("回復補正値")]
        protected InstantCorrectionManager m_correction;

        public HealModule(GameObject obj, AStatus<int> status) {
            m_obj = obj;
            m_status = status;
            
            m_correction = new InstantCorrectionManager();
        }

        public void Heal(int amount) {
            var healValue = amount;
            
            healValue = (int)m_correction.ExecuteCorrection(healValue);
            
            m_status.Increase(healValue);
            HealUEvent?.Invoke(m_obj,healValue);
        }

        public void InstantHeal(int amount) {
            m_status.Increase(amount);
            HealUEvent?.Invoke(m_obj,amount);
        }

        public void AddHealCorrection(InstantCorrection correction) {
            m_correction.AddCorrection(correction);
        }

        public void RemoveHealCorrection(InstantCorrection correction) {
            m_correction.RemoveCorrection(correction);
        }
    }
}