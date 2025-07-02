using System;
using Project.Script.Bullet.Destroy.Interface;
using Project.Script.Bullet.Range.Interface;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using VContainer;

namespace Project.Script.Bullet.Destroy.Conditions {
    [Serializable]
    public class RangeDestroyCondition : ADestroyCondition {

        [SerializeField, LabelText("消滅距離"), ProgressBar(0.0f, 1000.0f)]
        protected float m_range = 100.0f;

        protected IRangeCounter m_counter;
        
        [Inject]
        public override void Start(IObjectResolver resolver) {
            m_counter = resolver.Resolve<IRangeCounter>();
            
            RegisterCounter();
        }

        protected void RegisterCounter() {
            Observable
                .EveryValueChanged(m_counter, x => m_counter.Range)
                .Subscribe(x => {
                    m_isDestroy = Mathf.Abs(x) > m_range ? true : false;
                }).Dispose();
        }
    }
}