using UnityCommonModule.Correction.Instant;

namespace Project.Script.Asset.Status.Health.Interface {
    /// <summary>
    /// ダメージを受けれるクラスに対して約束するインターフェース
    /// </summary>
    public interface IDamageable {

        public void Damage(int amount);
        
        public void InstantDamage(int amount);
        
        public void AddDamageCorrection(InstantCorrection correction);
        
        public void RemoveDamageCorrection(InstantCorrection target);

    }
}