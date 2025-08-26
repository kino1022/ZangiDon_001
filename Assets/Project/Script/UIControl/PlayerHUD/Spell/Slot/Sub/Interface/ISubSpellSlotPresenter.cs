using Teiwas.Script.Spell.Instance.Sub.Insterface;
using Teiwas.Script.Spell.Slot.Sub.Instance;
using Teiwas.Script.UIControl.PlayerHUD.Spell.Slot;

namespace Teiwas.Script.UIControl.PlayerHUD.Spell.Sub.Interface {
    public interface ISubSpellSlotPresenter : 
        ISpellSlotPresenter<ISubSpellSlot,ISubSpellInstance> 
    {
        
    }
}