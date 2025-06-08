using System;
using Project.Script.Rune.Manage.Modules;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Rune {
    [Serializable]
    public class SupportEffectInstance {
        
        [OdinSerialize,LabelText("使用回数")] protected RuneCastCountModule m_count;

        public Action<GameObject> Activate;
        
        public SupportEffectInstance(RuneData data) {
            Activate += data.m_effect.Activate;
        }

        public void OnActivate(GameObject caster) {
            Activate?.Invoke(caster);
            m_count?.OnCast();
        }
        
    }
}