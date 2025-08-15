using System;

namespace Teiwas.Script.Spell.Manager.Module.Interface {
    /// <summary>
    /// スペル管理クラスのスペルが満タンかどうかを管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface IFullSpellManager : IDisposable {

        /// <summary>
        /// スペルが満タンがどうかの真偽値
        /// </summary>
        /// <value></value>
        bool IsFull { get; }
    }
}
