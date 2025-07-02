using Teiwas.Script.Bullet.Context.Intetface;

namespace Teiwas.Script.Bullet.Movement.Interface {
    /// <summary>
    /// 弾丸の現在の速度を管理するクラスに対して与えるインターフェース
    /// </summary>
    public interface IBulletSpeedHolder : IBulletContextApplicable  {
        public float Speed { get; }
    }
}