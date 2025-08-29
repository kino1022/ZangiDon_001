using System;
using Teiwas.Script.Spell.Factory.Sub.Interface;
using Teiwas.Script.Spell.Instance.Sub.Insterface;
using Teiwas.Script.Spell.Slot.Factory.Interface;
using Teiwas.Script.Spell.Slot.Sub.Instance;

namespace Teiwas.Script.Spell.Slot.Factory {
    [Serializable]
    public class SubSpellSlotFactory : ASpellSlotFactory<ISubSpellSlot, ISubSpellInstance>, ISubSpellSlotFactory {

        public override ISubSpellSlot Create() {
            throw new System.NotImplementedException();
        }
    }
}