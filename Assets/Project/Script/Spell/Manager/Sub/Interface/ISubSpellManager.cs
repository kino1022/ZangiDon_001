using Teiwas.Script.Spell.Instance.Sub.Insterface;
using Teiwas.Script.Spell.Manager.Interface;
using Teiwas.Script.Spell.Slot.Sub.Instance;

namespace Teiwas.Script.Spell.Manager.Sub {
    
    public interface ISubSpellManager : ISpellManager<ISubSpellSlot, ISubSpellInstance> {
        
    }
}