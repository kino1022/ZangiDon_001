namespace Teiwas.Script.Rune.Interface {
    /// <summary>
    /// ルーンの効果のインスタンスに使用するデータに対して与えるインターフェース
    /// </summary>
    public interface IRuneEffectData {
        /// <summary>
        /// その効果が使用できる回数
        /// </summary>
        public int Amount { get; }
    }
}