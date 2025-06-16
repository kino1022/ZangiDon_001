using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Project.Script.UIControl.Utility {
    public class UiDestroyModule {
        
        protected GameObject m_ui;

        protected float m_duration;

        public UiDestroyModule(GameObject uiPrefab, float duration) {
            m_ui = uiPrefab;
            this.m_duration = duration;
        }

        protected async UniTask UiDisposeCounter() {
            var token = m_ui.GetCancellationTokenOnDestroy();

            try {
                await UniTask.Delay(TimeSpan.FromSeconds(m_duration));
                GameObject.Destroy(m_ui);
            }
            catch (OperationCanceledException) {
                
            }
        }
    }
}