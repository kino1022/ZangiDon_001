using System;
using Project.Script.Bullet.Destroy.Interface;
using Project.Script.Bullet.Range;
using Project.Script.Bullet.Range.Interface;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using VContainer;

namespace Project.Script.Bullet.Destroy.Conditions {
    [Serializable]
    public class RangeDestroyCondition : ADestroyCondition {

        [SerializeField, LabelText("消滅距離"), ProgressBar(0.0f, 10000.0f)]
        protected float m_range = 100.0f;
        [OdinSerialize]
        protected IRangeCounter m_counter;

        protected CompositeDisposable m_disposable;

        [Inject]
        public override void Start(IObjectResolver resolver, GameObject bullet) {
            m_counter = new BulletRangeCounter(bullet);
            m_disposable = new CompositeDisposable();
            RegisterCounter();
        }

        public override void Dispose() {
            m_disposable.Dispose();
        }

        protected void RegisterCounter() {
            Observable
                .EveryValueChanged(m_counter, x => x.Range)
                .Subscribe(x => {
                    m_isDestroy = Mathf.Abs(x) > m_range ? true : false;
                })
                .AddTo(m_disposable);
        }
    }
}
