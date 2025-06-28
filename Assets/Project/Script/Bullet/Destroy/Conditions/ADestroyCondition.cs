using Project.Script.Bullet.Destroy.Interface;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Project.Script.Bullet.Destroy.Conditions {
    public abstract class ADestroyCondition : IDestroyCondition {
        
        [SerializeField, LabelText("条件が満たされているか")]
        protected bool m_isDestroy = false;

        public bool IsDestroy => m_isDestroy;
        
        [Inject]
        public abstract void Start(IObjectResolver resolver);
    }
}