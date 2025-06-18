namespace Project.Script.Rune.Interface {
    public interface IRune {

        public bool GetIsActive();
        
        /// <summary>
        /// メインの効果
        /// </summary>
        public ICastable Main { get; }
        
        /// <summary>
        /// サブの効果
        /// </summary>
        public IActivatable Sub { get; }
        
        
    }
}