using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Slot.Interface;

namespace Teiwas.Script.Spell.Slot.Factory.Interface {
    /// <summary>
    /// ISpellSlotのインスタンスを生成するクラスに対して約束するインターフェース
    /// </summary>
    /// <typeparam name="Slot">生成するISpellSlotの型</typeparam>
    /// <typeparam name="Instance">ISpellSlotで管理するISpellInstanceの型</typeparam>
    public interface ISpellSlotFactory<Slot,Instance> 
        where Slot : ISpellSlot<Instance> where Instance : ISpellInstance {
        /// <summary>
        /// ISpellSlotのインスタンス化を行う
        /// </summary>
        /// <returns></returns>
        Slot Create();
    }
}