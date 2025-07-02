using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Rune.Interface;
using Teiwas.Script.Rune.Manage.Modules;
using UnityEngine;

namespace Teiwas.Script.Rune {
    [Serializable]
    public class MainEffectInstance : IMainEffect, IDisposable
    {

        protected RuneCastCountModule m_countModule;

        protected Action<GameObject> CastAction;

        public  bool m_isActive = true;
        

        public MainEffectInstance(
            Action<GameObject> castAction,
            RuneCastCountModule count
            )
        {
            CastAction = castAction;
            m_countModule = count;
        }

        public void Dispose()
        {
            m_isActive = false;
        }

        public int GetAmount()
        {
            return m_countModule.GetAmount();
        }

        public bool GetIsActive() {
            return m_isActive;
        }


        public void OnCast(GameObject caster)
        {
            CastAction?.Invoke(caster);
            m_countModule.OnCast();
        }
        
    }
}