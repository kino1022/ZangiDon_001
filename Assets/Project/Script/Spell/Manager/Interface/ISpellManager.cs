using ObservableCollections;
using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Slot.Interface;

namespace Teiwas.Script.Spell.Manager.Interface {

    /// <summary>
    /// スペルを管理するクラスに対して共通して約束するインターフェース
    /// </summary>
    /// <typeparam name="S"></typeparam>
    public interface ISpellManager<S> where S : ISpellSlot {
        /// <summary>
        /// 現在管理しているスペルのスロット
        /// </summary>
        /// <value></value>
        IReadOnlyObservableDictionary<int, S> Spells { get; }

        /// <summary>
        /// 管理できる量
        /// </summary>
        /// <value></value>
        int Length { get; }

        /// <summary>
        /// スロットが満タンかどうか
        /// </summary>
        /// <value></value>
        bool IsFull { get; }

    }
}
