using System;
using Teiwas.Script.Spell.Instance.Interface;
using VContainer.Unity;

namespace Teiwas.Script.Spell.Manager.Selector.Module.Interface {

    /// <summary>
    /// メインスペルとサブスペルの供給率を管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface ISpellSupplyPattern : IStartable , IDisposable {

        ISpellInstance Supply();

    }
}
