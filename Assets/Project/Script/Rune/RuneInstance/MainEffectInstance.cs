using System;
using Project.Script.Rune.Interface;
using Project.Script.Rune.Manage.Modules;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Rune {
    [Serializable]
    public class MainEffectInstance : ICastable {
        
        [OdinSerialize, LabelText("使用回数")] protected RuneCastCountModule m_count;
        
        protected Action<GameObject> m_OnCast;

        public int GetAmount() {
            return m_count.GetAmount();
        }

        public MainEffectInstance(RuneData data) {

            m_OnCast += data.m_cast.OnCast;

            m_count = new RuneCastCountModule(data.m_cast.GetAmount());
        }

        public void OnCast(GameObject caster) {
            m_OnCast?.Invoke(caster);
            m_count?.OnCast();
        }
    }
}