using System;
using Project.Script.Rune.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Rune {
    [Serializable]
    public class RuneInstance : IDisposable {

        [OdinSerialize, LabelText("一文字目の時の効果")] protected MainEffectInstance m_mainEffect;

        [OdinSerialize, LabelText("二文字目以降の際の効果")] protected SupportEffectInstance m_supportEffect;

        public ICastable Cast => m_mainEffect;

        public SupportEffectInstance Support => m_supportEffect;

        public RuneInstance (RuneData data) {

            m_mainEffect = new MainEffectInstance(data);
            m_supportEffect = new SupportEffectInstance(data);

            AddListenerDisposeHandler(m_mainEffect.DisposeHandler);
            AddListenerDisposeHandler (m_supportEffect.DisposeHandler);
            
        }


        public void Dispose () {
            RemoveListenerDisposeHandler(m_mainEffect.DisposeHandler);
            RemoveListenerDisposeHandler(m_supportEffect.DisposeHandler);
        }

        #region Listener 

        public void AddListenerDisposeHandler (IRuneDisposeHandler handler) {
            handler.RuneDisposeEvent += OnDisposeHandle;
        }

        public void RemoveListenerDisposeHandler (IRuneDisposeHandler handler) {
            handler.RuneDisposeEvent -= OnDisposeHandle;
        }

		#endregion

		#region Hook 

        protected virtual void OnDisposeHandle () {
            
            Dispose();
        }

		#endregion
	}
}