using Teiwas.Script.Spell.Instance.Main.Interface;
using Teiwas.Script.Spell.Slot.Main.Interface;

namespace Teiwas.Script.UIControl.PlayerHUD.Spell.Slot.Factory.Interface {
    public interface IMainSpellSlotPresenterFactory<Product> : 
        ISpellSlotPresenterFactory<Product,IMainSpellSlot,IMainSpellInstance,ISpellSlotUIView> 
        where Product : IMainSpellSlotPresenter
    {
        
    }
}