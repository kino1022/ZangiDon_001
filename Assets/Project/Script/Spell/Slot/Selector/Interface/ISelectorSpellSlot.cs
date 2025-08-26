using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Slot.Interface;

namespace Teiwas.Script.Spell.Slot.Selector.Interface {
    public interface ISelectorSpellSlot : ISpellSlot<ISpellInstance> {
        /// <summary>
        /// 選択されたスペルを返して、自分のフィールドをnullにする
        /// </summary>
        /// <returns></returns>
        ISpellInstance Select();
    }
}