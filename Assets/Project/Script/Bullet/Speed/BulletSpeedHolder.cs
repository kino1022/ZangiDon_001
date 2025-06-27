using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Project.Script.Bullet.Speed.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using VContainer.Unity;

namespace Project.Script.Bullet.Speed {
    
    [Serializable, LabelText("弾丸の速度")]
    public class BulletSpeedHolder : IBulletSpeedHolder , IInitializable , IDisposable {

        [SerializeField, LabelText("速度")] protected float m_speed = 0.0f;
        public float Speed => m_speed;
        
        [OdinSerialize, Title("初速度")] protected IBulletFirstSpeedHolder m_first;
        public IBulletFirstSpeedHolder First => m_first;

        [OdinSerialize, Title("加速度")] protected IBulletAccelerationHolder m_acce;
        public IBulletAccelerationHolder Acceleration => m_acce;
        
        protected CancellationTokenSource m_cts = new CancellationTokenSource();

        public void Initialize() {
            //初速度の代入処理
            m_speed = First.Speed;
            
            //トークンの取得処理
            CancellationToken token = m_cts.Token;
            
            //加速度の適用処理の開始
            ApplyAcceleration().Forget();
        }

        public void Dispose() {
            m_cts.Cancel();
        }

        protected async UniTask ApplyAcceleration() {
            while (!m_cts.IsCancellationRequested) {
                try {
                    await UniTask.Delay(TimeSpan.FromSeconds(1));
                    m_speed += Acceleration.Acceleration;
                }
                catch (OperationCanceledException) {
                    
                }
            }
        }
    }
}