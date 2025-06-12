using System;
using Project.Script.Rune.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Rendering;

namespace Project.Script.Rune {
    [Serializable]
    public class RuneInstance : IDisposable
    {

        protected MainEffectInstance m_main;

        protected SubEffectInstance m_sub;

        public ICastable Main => m_main;

        public IActivatable Sub => m_sub;

        public RuneInstance(RuneData data)
        {
            m_main = new MainEffectInstance(data);
            m_sub = new SubEffectInstance(data);
        }

        public void Dispose()
        {

        }

        protected void ObserveActiveInstance()
        {
            
        }
	}
}