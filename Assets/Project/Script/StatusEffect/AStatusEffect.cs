using System;
using Project.Script.StatusEffect.Data;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.StatusEffect {
    [Serializable]
    public abstract class AStatusEffect {
        [OdinSerialize, LabelText("エフェクトの情報")]
        protected StatusEffectData m_data;
        
        public abstract void Activate (GameObject target); 
        
        public abstract void Deactivate (GameObject target);
    }
}