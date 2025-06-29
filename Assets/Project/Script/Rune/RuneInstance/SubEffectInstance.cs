using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Bullet.Context.Intetface;
using Teiwas.Script.Rune.Definition;
using Teiwas.Script.Rune.Interface;
using Teiwas.Script.Rune.Manage.Modules;
using UnityEngine;

namespace Teiwas.Script.Rune {
    [Serializable]
    public class SubEffectInstance : ISubEffect, IDisposable
    {
        protected IBulletContext m_context;
        
        protected RuneCastCountModule m_countModule;

        protected ActivateTiming m_timing;

        protected Action<GameObject> ActivateAction;

        public bool isActive = true;
        
        public IBulletContext Context => m_context;

        public SubEffectInstance(RuneData data)
        {
            ActivateAction = data.Sub.Activate;
            m_countModule = new RuneCastCountModule(data.Sub.GetAmount(), this);
            m_timing = data.Sub.GetTiming();
            m_context = data.Sub.Context;
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