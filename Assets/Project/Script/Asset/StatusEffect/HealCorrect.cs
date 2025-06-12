using System;
using Project.Script.Asset.Status.Health;
using Project.Script.StatusEffect;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Correction;
using UnityCommonModule.Correction.Definition;
using UnityCommonModule.Correction.Instant;
using UnityEngine;

namespace Project.Script.Asset.StatusEffect {
    [Serializable,LabelText("回復量補正")]
    public class HealCorrect : AStatusEffect {

        [OdinSerialize, LabelText("適用する補正")] protected InstantCorrection m_correction;

        public override void Activate(GameObject target) {
            var health = target.GetComponent<Health>();
            
            health.Healable.AddHealCorrection(m_correction);
        }

        public override void Deactivate(GameObject target) {
            var health = target.GetComponent<Health>();
            
            health.Healable.RemoveHealCorrection(m_correction);
        }

    }
}