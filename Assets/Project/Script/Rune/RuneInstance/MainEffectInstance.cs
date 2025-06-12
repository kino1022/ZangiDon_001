using System;
using Project.Script.Rune.Interface;
using Project.Script.Rune.Manage.Modules;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Rune {
    [Serializable]
    public class MainEffectInstance : ICastable, IDisposable
    {

        protected RuneCastCountModule m_countModule;


        protected Action<GameObject> CastAction;

        public  bool m_isActive = true;
        

        public MainEffectInstance(RuneData data)
        {
            CastAction = data.Main.OnCast;
            m_countModule = new RuneCastCountModule(data.Sub.GetAmount(), this);
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