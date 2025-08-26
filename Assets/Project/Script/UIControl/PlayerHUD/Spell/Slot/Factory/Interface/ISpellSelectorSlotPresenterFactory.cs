using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Slot.Interface;
using Teiwas.Script.Spell.Slot.Selector.Interface;
using Teiwas.Script.UIControl.PlayerHUD.Spell.Slot.Selector;
using Unity.VisualScripting;

namespace Teiwas.Script.UIControl.PlayerHUD.Spell.Slot.Factory.Interface {
    public interface ISpellSelectorSlotPresenterFactory<Product> : 
        ISpellSlotPresenterFactory<Product,ISelectorSpellSlot,ISpellInstance,ISpellSlotUIView>
        where Product : ISelectorSpellSlotPresenter
    {
    
    }
}