using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Rune.Definition;
using Teiwas.Script.Rune.Interface;
using Teiwas.Script.Rune.Manage.Modules;
using UnityEngine;

namespace Teiwas.Script.Rune {
    [Serializable]
    public class SubEffectInstance : ISubEffect, IDisposable
    {
        protected RuneCastCountModule m_countModule;

        protected ActivateTiming m_timing;

        protected Action<GameObject> ActivateAction;

        public bool isActive = true;

        public SubEffectInstance(RuneData data)
        {
            ActivateAction = data.Sub.Activate;
            m_countModule = new RuneCastCountModule(data.Sub.GetAmount(), this);
            m_timing = data.Sub.GetTiming();
        }

        public void Dispose()
        {
            isActive = false;
        }

        public int GetAmount()
        {
            return m_countModule.GetAmount();
        }

        public ActivateTiming GetTiming()
        {
            return m_timing;
        }

        public void Activate(GameObject caster)
        {
            ActivateAction?.Invoke(caster);
            m_countModule.OnCast();
        }
    }
}