using Project.Script.Rune;

namespace DefaultNamespace {
    /// <summary>
    /// ルーンを供給するクラスに対して約束するインターフェース
    /// </summary>
    public interface IRuneSupplier {
        public ARuneBase SupplyRune();
    }
}