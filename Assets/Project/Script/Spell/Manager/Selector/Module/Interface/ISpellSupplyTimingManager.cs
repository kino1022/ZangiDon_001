using System;
using VContainer.Unity;

namespace Teiwas.Script.Spell.Manager.Selector.Module.Interface {

    /// <summary>
    /// ISpellSelectorに対してスペルの補充タイミングを通知するクラスに対して約束するインターフェース
    /// </summary>
    public interface ISpellSupplyTimingManager : IStartable, IDisposable {

        /// <summary>
        /// 補充タイミングで発火するアクション
        /// </summary>
        /// <value></value>
        Action OnSupply { get; set; }

    }
}
