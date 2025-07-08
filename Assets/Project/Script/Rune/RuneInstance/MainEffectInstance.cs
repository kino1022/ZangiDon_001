using System;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Rune.Interface;
using Teiwas.Script.Rune.Manage.Modules;
using UnityEngine;

namespace Teiwas.Script.Rune {
    [Serializable]
    public class MainEffectInstance : IMainEffect, IDisposable {

        protected RuneCastCountModule m_count;

        protected bool m_isActive = true;

        protected Action<GameObject> m_onCast;
        
        public int Amount => m_count.GetAmount();
        public bool IsActive => m_isActive;
        public Action<GameObject> OnCast => m_onCast;

        public MainEffectInstance(
            RuneCastCountModule count,
            Action<GameObject> onCast
            ) {
            m_count = count;
            m_onCast = onCast;

            ObserveCounter();
        }


        public void Dispose() {
            m_isActive = false;
            m_onCast = null;
        }

        protected void ObserveCounter() {
            Observable
                .EveryValueChanged(m_count, x => x.GetAmount())
                .Subscribe(x => {
                    if (x < 0) {
                        Dispose();
                    }
                }).Dispose();
        }
    }
}