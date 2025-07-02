using System.Collections.Generic;
using UnityCommonModule.Correction.Interface;

namespace Teiwas.Script.Bullet.Movement.Acceleration.Interface {
    /// <summary>
    /// 弾丸の加速度を保持するクラスに対して約束するインターフェース
    /// </summary>
    public interface IBulletAccelerationHolder {
        
        public float Acceleration { get; }
        
        public void ApplyCorrect (List<ICorrection> corrections);
    }
}