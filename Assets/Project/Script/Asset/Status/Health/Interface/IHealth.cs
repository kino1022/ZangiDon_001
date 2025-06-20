using UnityCommonModule.Status.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace Teiwas.Script.Asset.Status.Health.Interface {
    public interface IHealth : IStatus<int> {
        public IDamageable Damage { get; }

        public IHealable Heal { get; }
        
        public UnityEvent<GameObject> DeathUEvent { get; set; }
    }
}