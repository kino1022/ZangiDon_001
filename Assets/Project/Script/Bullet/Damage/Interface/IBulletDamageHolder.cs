using UnityCommonModule.Correction.Interface;

namespace Project.Script.Bullet.Damage {
    /// <summary>
    /// 弾丸のダメージを管理するクラスに約束するインターフェース
    /// </summary>
    public interface IBulletDamageHolder {
        
        public int Damage { get; }
        
        public ICorrector Correction { get; }
    }
}