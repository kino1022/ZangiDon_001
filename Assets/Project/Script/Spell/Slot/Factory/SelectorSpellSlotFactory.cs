using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Slot.Factory.Interface;
using Teiwas.Script.Spell.Slot.Selector.Interface;

namespace Teiwas.Script.Spell.Slot.Factory {
    public class SelectorSpellSlotFactory : ASpellSlotFactory<ISelectorSpellSlot,ISpellInstance> , ISelectorSpellSlotFactory {

        public SelectorSpellSlotFactory():base() {}

        public override ISelectorSpellSlot Create() {
            throw new System.NotImplementedException();
        }
    }
}