namespace Project.Script.Bullet.Homing.Interface {
    /// <summary>
    /// 誘導率を管理するインターフェース
    /// </summary>
    public interface IHomingForce {
        
        /// <summary>
        /// 上方向への誘導率
        /// </summary>
        public float Upper { get; }
        
        /// <summary>
        /// 下方向への誘導率
        /// </summary>
        public float Lower { get; }
        
        /// <summary>
        /// 右方向への誘導率
        /// </summary>
        public float Right { get; }
        
        /// <summary>
        /// 左方向への誘導率
        /// </summary>
        public float Left { get; }
        
        
        public void Add(IHomingForce force);
    }
}