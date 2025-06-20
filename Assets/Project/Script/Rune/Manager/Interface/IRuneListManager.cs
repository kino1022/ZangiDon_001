using ObservableCollections;
using Teiwas.Script.Interface;
using Teiwas.Script.Rune.Interface;

namespace Teiwas.Script.Rune.Manager.Interface {
    public interface IRuneListManager {
        /// <summary>
        /// ルーンのリストが満タンかどうか
        /// </summary>
        public bool IsFull { get; }
        public IReadOnlyObservableList<IRune> List { get; }
        

        public void Add(IRune rune);
        
        public void Remove(IRune rune);
    }
}