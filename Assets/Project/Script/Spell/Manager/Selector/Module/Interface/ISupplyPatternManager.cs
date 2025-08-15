using System;
using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Instance.Main.Interface;
using Teiwas.Script.Spell.Instance.Sub.Insterface;
using VContainer.Unity;

namespace Teiwas.Script.Spell.Manager.Selector.Module.Interface {
    /// <summary>
    /// メインスペルとサブスペルの供給割合を管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface ISupplyPatternManager : IStartable , IDisposable {

        /// <summary>
        /// 渡されたメインとサブのスペルからどちらを供給するかどうか判断する
        /// </summary>
        /// <param name="spell"></param>
        /// <returns></returns>
        ISpellInstance DecideSupply((IMainSpellInstance,ISubSpellInstance) spell);

    }
}
