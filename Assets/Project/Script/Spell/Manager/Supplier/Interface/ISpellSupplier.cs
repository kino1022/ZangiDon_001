using Teiwas.Script.Spell.Instance.Main.Interface;
using Teiwas.Script.Spell.Instance.Sub.Insterface;

namespace Teiwas.Script.Spell.Manager.Supplier.Interface {
    /// <summary>
    /// 他のクラスに対してスペルのインスタンスを供給するクラスに対して約束するインターフェース
    /// </summary>
    public interface ISpellSupplier {

        /// <summary>
        /// メインのスペルとサブのスペルを両方同時に供給する
        /// </summary>
        /// <param name="SupplyBath("></param>
        /// <returns></returns>
        (IMainSpellInstance, ISubSpellInstance) SupplyBath();

        /// <summary>
        /// メインのスペルを供給する
        /// </summary>
        /// <returns></returns>
        IMainSpellInstance SupplyMain();

        /// <summary>
        /// サブのスペルを供給する
        /// </summary>
        /// <returns></returns>
        ISubSpellInstance SupplySub();

    }
}
