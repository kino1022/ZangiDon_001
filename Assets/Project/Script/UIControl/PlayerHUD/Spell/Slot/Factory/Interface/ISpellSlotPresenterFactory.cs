using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Slot.Interface;
using Teiwas.Script.Spell.Slot.Selector.Interface;

namespace Teiwas.Script.UIControl.PlayerHUD.Spell.Slot.Factory.Interface {
    public interface ISpellSlotPresenterFactory<Product,Slot,Instance,SlotView>
        where Product : ISpellSlotPresenter<Slot,Instance> 
        where Slot : ISpellSlot<Instance>
        where Instance : ISpellInstance
        where SlotView : ISpellSlotUIView
    {
        Product Create (Slot model, SlotView view);
    }
}