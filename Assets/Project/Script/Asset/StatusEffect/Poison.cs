using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using Teiwas.Script.StatusEffect;
using UnityEngine;

namespace Teiwas.Script.Asset.StatusEffect {
    [Serializable]
    public class Poison : AStatusEffect {

        [SerializeField, LabelText("ダメージ量")]
        protected float m_damage = Mathf.Min(0, 0);

        [SerializeField, LabelText("ダメージ間隔")]
        protected float m_interval = Mathf.Min(0, 0);

        [SerializeField, LabelText("持続時間")]
        protected float m_duration = Mathf.Min(0, 0);

        protected CancellationTokenSource cts = new CancellationTokenSource();

        public override void Activate(GameObject target) {
            CancellationToken token = cts.Token;
        }

        public override void Deactivate(GameObject target) {

        }

        protected async UniTask DamageCounter() {
            var time = 0.0f;

            while(time < m_duration || cts.IsCancellationRequested) {
                try {
                    await UniTask.Delay(
                        TimeSpan.FromSeconds(0.1f),
                        cancellationToken:cts.Token
                        );

                    time += 0.1f;
    
                }
                catch(OperationCanceledException) {
                    m_damage = 0.0f;
                }
            }
        }
    }
}
