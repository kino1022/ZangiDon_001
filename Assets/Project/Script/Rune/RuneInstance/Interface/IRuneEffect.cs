namespace Teiwas.Script.Rune.Interface {
    public interface IRuneEffect {
        /// <summary>
        /// ルーンの使用回数が0になるなどでルーンが使用不可ならfalse
        /// </summary>
        public bool IsActive { get; }
        /// <summary>
        /// ルーンの残り使用回数
        /// </summary>
        public int Amount { get; }
    }
}