using System;
using Project.Script.Bullet.Destroy.Interface;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Project.Script.Bullet.Destroy.Conditions {
    [Serializable]
    public abstract class ADestroyCondition : IDestroyCondition, IDisposable {

        [SerializeField, LabelText("条件が満たされているか")]
        protected bool m_isDestroy = false;

        public bool IsDestroy => m_isDestroy;

        public abstract void Start(IObjectResolver resolver, GameObject bullet);

        public abstract void Dispose();
    }
}
