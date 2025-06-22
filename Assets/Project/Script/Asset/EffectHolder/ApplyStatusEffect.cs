using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Rune.Effect.Interface;
using Teiwas.Script.StatusEffect;
using UnityCommonModule.Correction;
using UnityEngine;

namespace Teiwas.Script.Asset.EffectHolder {
    [Serializable,LabelText("ステータスエフェクト適用")]
    public class ApplyStatusEffect : IEffectHolder {
        
        [OdinSerialize,LabelText("適用エフェクト")] protected AStatusEffect m_effect;
        
        public void Apply(GameObject target) {
            m_effect.Activate(target);
        }
    }
}