using System;

namespace Teiwas.Script.Spell.Manager.Module.Interface {
    /// <summary>
    /// ISpellManagerのIsFullを監視するクラスに対して約束するインターフェース
    /// </summary>
    public interface IManagerFillObserver : IDisposable {
    
        /// <summary>
        /// 現在マネージャは満たされているかどうか
        /// </summary>
        bool IsFull { get; }
        
    }
}