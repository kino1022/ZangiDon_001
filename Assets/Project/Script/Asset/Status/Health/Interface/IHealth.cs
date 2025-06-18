using UnityCommonModule.Status.Interface;

namespace Project.Script.Asset.Status.Health.Interface {
    public interface IHealth : IStatus<int> {
        public IDamageable Damage { get; }

        public IHealable Heal { get; }
    }
}