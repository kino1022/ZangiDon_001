using ObservableCollections;
using Project.Script.Interface;
using Project.Script.Rune.Interface;

namespace Project.Script.Rune.Manager.Interface {
    public interface IRuneListManager {
        /// <summary>
        /// ルーンのリストが満タンかどうか
        /// </summary>
        public bool IsFull { get; }
        public IReadOnlyObservableList<IRune> List { get; }
        
        public IReceiver<IRune> Receiver { get; }

        public void Add(IRune rune);
        
        public void Remove(IRune rune);
    }
}