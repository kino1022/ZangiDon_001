using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Instance.Main.Interface;
using Teiwas.Script.Spell.Instance.Sub.Insterface;
using Teiwas.Script.Spell.Slot.Interface;

namespace Teiwas.Script.Spell.Slot.Selector.Interface {
    /// <summary>
    /// ISpellSelectorで扱われるISpellSlotに対して約束するインターフェース
    /// </summary>
    public interface ISelectorSpellSlot : ISpellSlot {
        /// <summary>
        /// 管理しているスペルのインスタンス
        /// </summary>
        /// <value></value>

        ISpellInstance Spell { get; }
    }
}
