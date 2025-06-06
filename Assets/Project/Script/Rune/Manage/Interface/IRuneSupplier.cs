namespace Project.Script.Rune.Manage.Interface {
    /// <summary>
    /// ルーンのインスタンスを供給するクラスに約束するインターフェース
    /// </summary>
    public interface IRuneSupplier {
        
        /// <summary>
        /// ルーンを供給するメソッド
        /// </summary>
        /// <returns></returns>
        public RuneInstance SupplyRune();
        
    }
}