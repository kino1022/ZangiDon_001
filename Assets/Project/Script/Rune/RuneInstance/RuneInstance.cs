using System;
using Project.Script.Rune.Definition;
using Project.Script.Rune.InstanceElement;
using Project.Script.Rune.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Rune {
    [Serializable]
    public class RuneInstance {
        
        [OdinSerialize,LabelText("一文字目の時の効果")] protected MainEffectInstance m_mainEffect;
        
        [OdinSerialize,LabelText("二文字目以降の際の効果")] protected SupportEffectInstance m_supportEffect;

        public ICastable Cast => m_mainEffect;
        
        public SupportEffectInstance Support => m_supportEffect;
        
        public RuneInstance(RuneData data) {
            
            m_mainEffect = new MainEffectInstance(data);
            m_supportEffect = new SupportEffectInstance(data);
            
        }
    }
}