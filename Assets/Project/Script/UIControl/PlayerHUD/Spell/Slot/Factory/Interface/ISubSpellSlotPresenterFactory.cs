using Teiwas.Script.Spell.Instance.Sub.Insterface;
using Teiwas.Script.Spell.Slot.Sub.Instance;
using Teiwas.Script.UIControl.PlayerHUD.Spell.Sub.Interface;

namespace Teiwas.Script.UIControl.PlayerHUD.Spell.Slot.Factory.Interface {
    public interface ISubSpellSlotPresenterFactory<product> 
        : ISpellSlotPresenterFactory<product,ISubSpellSlot,ISubSpellInstance,ISpellSlotUIView> 
        where product : ISubSpellSlotPresenter
    {
        
    }
}