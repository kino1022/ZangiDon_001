namespace Project.Script.Bullet.Speed.Interface {
    /// <summary>
    /// 弾丸の初速と弾速を合計したものを管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface IBulletSpeedHolder {
        
        public IBulletFirstSpeedHolder First { get; }
        
        public IBulletAccelerationHolder Acceleration { get; }
        
        public float Speed { get; }
    }
}