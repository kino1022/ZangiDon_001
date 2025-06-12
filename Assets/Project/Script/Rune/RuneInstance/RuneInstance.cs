using System;
using System.Collections.Generic;
using Project.Script.Rune.Interface;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Rendering;
using Observable = R3.Observable;

namespace Project.Script.Rune {
    [Serializable]
    public class RuneInstance : IDisposable 
    {

        protected MainEffectInstance m_main;

        protected SubEffectInstance m_sub;
        
        protected List<ReactiveProperty<bool>> activeObservers = new List<ReactiveProperty<bool>>();

        public ICastable Main => m_main;

        public IActivatable Sub => m_sub;

        protected bool m_isActive;

        public RuneInstance(RuneData data)
        {
            m_main = new MainEffectInstance(data);
            m_sub = new SubEffectInstance(data);
            ObserveActiveInstance();
        }

        public void Dispose() {
            this.m_isActive = false;
        }
        
        public bool GetIsActive() => m_isActive;

        protected void ObserveActiveInstance() {
            
            Observable
                .EveryValueChanged(m_main, x => x.m_isActive == false)
                .Subscribe( x => {
                    this.Dispose();
                })
                .Dispose();

            Observable
                .EveryValueChanged(m_sub,x => x.isActive == false).
                Subscribe(x => {
                    this.Dispose();
                })
                .Dispose();
            
        }
	}
}