namespace Project.Script.Bullet.Homing.Interface {
    /// <summary>
    /// 誘導率を管理するクラスに約束するインターフェース
    /// </summary>
    public interface IHomingForceHolder {
        
        /// <summary>
        /// 管理しているIHomingForce
        /// </summary>
        public IHomingForce Force { get; }
        
        public void Add (IHomingForce force);
        
    }
}