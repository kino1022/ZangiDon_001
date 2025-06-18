
using UnityCommonModule.Correction.Interface;

namespace Project.Script.Asset.Status.Health.Interface {
    /// <summary>
    /// ダメージを受けれるクラスに対して約束するインターフェース
    /// </summary>
    public interface IDamageable {

        public void Damage(int amount);
        
        public void InstantDamage(int amount);
        
        public void AddCorrection(ICorrection correction);
        
        public void RemoveCorrection(ICorrection target);

    }
}