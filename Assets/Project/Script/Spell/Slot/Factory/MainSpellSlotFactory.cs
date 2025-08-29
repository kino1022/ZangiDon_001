using System;
using Teiwas.Script.Spell.Instance.Main.Interface;
using Teiwas.Script.Spell.Slot.Factory.Interface;
using Teiwas.Script.Spell.Slot.Main.Interface;

namespace Teiwas.Script.Spell.Slot.Factory {
    [Serializable]
    public class MainSpellSlotFactory : ASpellSlotFactory<IMainSpellSlot, IMainSpellInstance> , IMainSpellSlotFactory {

        public override IMainSpellSlot Create() {
            throw new System.NotImplementedException();
        }
    }
}