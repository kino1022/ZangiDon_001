using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.StatusEffect.Data;
using UnityEngine;

namespace Teiwas.Script.StatusEffect {
    [Serializable]
    public abstract class AStatusEffect
    {

        [OdinSerialize, LabelText("エフェクトの情報")]
        protected StatusEffectData m_data;

        public abstract void Activate(GameObject target);

        public abstract void Deactivate(GameObject target);
        
    }
}