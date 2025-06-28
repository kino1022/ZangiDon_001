using JetBrains.Annotations;
using ObservableCollections;
using Teiwas.Script.Interface;
using Teiwas.Script.Rune.Interface;

namespace Teiwas.Script.Rune.Manager.Interface {
    public interface IRuneListManager {
        /// <summary>
        /// ルーンのリストが満タンかどうか
        /// </summary>
        public bool IsFull { get; }

        public int Amount { get; }
        
        public IReadOnlyObservableDictionary<int,IRune> List { get; }

        public void Add(IRune rune);
        
        public void Remove(IRune rune);
    }
}