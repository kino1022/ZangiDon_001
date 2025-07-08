using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using Teiwas.Script.Bullet.Movement.Acceleration.Interface;
using Unity.VisualScripting;
using UnityCommonModule.Correction;
using UnityCommonModule.Correction.Interface;
using UnityEngine;

namespace Teiwas.Script.Bullet.Movement.Acceleration {
    [Serializable]
    public class VariableAccerelation : IBulletAccelerationHolder, IInitializable, IDisposable {

        [SerializeField, LabelText("時間による変化")]
        protected AnimationCurve m_curve;

        [SerializeField, LabelText("変化が終了する時間"), ProgressBar(0.0f, 100.0f)]
        protected float m_maxTime = 0.0f;
        [SerializeField, LabelText("加速度")]
        protected float m_acce = 0.0f;

        public float Acceleration => m_acce;

        protected CancellationTokenSource m_cts = new CancellationTokenSource();

        protected ICorrector m_corrector = new CorrectionManager();

        public void Initialize() {
            CancellationToken token = m_cts.Token;


        }

        public void Dispose() {

        }

        protected async UniTask UpdateAcceleration() {
            Debug.Log($"{GetType().Name}の加速度更新処理を開始します");

            float progress = 0.0f;

            while(!m_cts.Token.IsCancellationRequested || m_maxTime <= progress) {
                try {

                    await UniTask.Delay(
                        TimeSpan.FromSeconds(0.1f),
                        cancellationToken: m_cts.Token
                        );

                    progress += 0.1f;

                    m_acce = m_corrector.Execute(m_curve.Evaluate(progress));

                }
                catch(OperationCanceledException) {
                    m_acce = 0.0f;
                }
            }
        }


        public void ApplyCorrect(List<ICorrection> corrections) {
            if(corrections.Count == 0) {

            }
        }
    }
}
