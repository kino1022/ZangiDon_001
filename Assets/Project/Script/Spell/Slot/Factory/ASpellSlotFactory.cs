using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Slot.Factory.Interface;
using Teiwas.Script.Spell.Slot.Interface;

namespace Teiwas.Script.Spell.Slot.Factory {
    public abstract class ASpellSlotFactory<Slot,Instance> 
        : ISpellSlotFactory<Slot,Instance> 
        where Slot : ISpellSlot<Instance> 
        where Instance : ISpellInstance 
    {
        
        protected ASpellSlotFactory() {}

        public abstract Slot Create();
    }
}