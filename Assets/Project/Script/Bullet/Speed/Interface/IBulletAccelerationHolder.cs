namespace Project.Script.Bullet.Speed.Interface {
    /// <summary>
    /// 弾速の加速度を管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface IBulletAccelerationHolder {
        public float Acceleration { get; }
    }
}