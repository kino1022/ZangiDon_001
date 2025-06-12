using System;
using Project.Script.Rune.Definition;
using Project.Script.Rune.Interface;
using Project.Script.Rune.Manage.Modules;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Rune {
    [Serializable]
    public class SupportEffectInstance {
        
        [OdinSerialize,LabelText("使用回数")] protected RuneCastCountModule m_count;

        public IRuneDisposeHandler DisposeHandler => m_count;

        protected ActivateTiming m_timing;

        protected Action<GameObject> Activate;
        
        public SupportEffectInstance(RuneData data) {
            m_count = new RuneCastCountModule(data.m_effect.amount);
            m_timing = data.m_effect.timing;
            Activate = data.m_effect.Activate;
        }

        public ActivateTiming GetTiming() {
            return m_timing;
        }

        public void OnActivate(GameObject caster) {
            Activate?.Invoke(caster);
            m_count?.OnCast();
        }
        
    }
}