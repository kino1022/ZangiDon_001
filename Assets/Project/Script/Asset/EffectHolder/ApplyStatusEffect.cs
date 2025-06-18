using System;
using Project.Script.Rune.Effect.Interface;
using Project.Script.StatusEffect;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Correction;
using UnityEngine;

namespace Project.Script.Asset.EffectHolder {
    [Serializable,LabelText("ステータスエフェクト適用")]
    public class ApplyStatusEffect : IEffectHolder {
        
        [OdinSerialize,LabelText("適用エフェクト")] protected AStatusEffect m_effect;
        
        public void Apply(GameObject target) {
            m_effect.Activate(target);
        }
    }
}