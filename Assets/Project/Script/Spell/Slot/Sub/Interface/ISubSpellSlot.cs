using Teiwas.Script.Spell.Instance.Sub.Insterface;

namespace Teiwas.Script.Spell.Slot.Sub.Interface {
    public interface ISubSpellSlot {

        ISubSpellInstance Sub { get; }

        bool RemoveInstance ();

    }
}
