using System;
using Project.Script.Bullet.Range.Interface;
using R3;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Script.Bullet.Range {
    [Serializable]
    
    public class BulletRangeCounter : IRangeCounter , IDisposable {
        
        [SerializeField, LabelText("移動距離")]
        protected float m_range = 0.0f;
        
        public float Range => m_range;
        
        protected Vector3 m_origin;
        
        protected GameObject m_bullet;
        

        [Inject]
        public BulletRangeCounter(GameObject bullet) {
            m_origin = bullet.transform.position;
            m_bullet = bullet;
        }

        public void Initialize() {
            
        }
        public void Dispose() {
            
        }

        protected void RegisterChangePosition() {
            Observable
                .EveryValueChanged(m_bullet, x => x.transform.position)
                .Subscribe(x => {
                    m_range = Vector3.Distance(m_origin, x);
                }).Dispose();
        }
    }
}