using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Slot.Selector.Interface;
using Teiwas.Script.UIControl.PlayerHUD.Spell.Slot;
using Teiwas.Script.UIControl.PlayerHUD.Spell.Slot.Factory.Interface;
using Teiwas.Script.UIControl.PlayerHUD.Spell.Slot.Selector;

namespace Project.Script.UIControl.PlayerHUD.Spell.Slot.Factory {
    public class SelectorSpellSlotPresenterFactory : 
        ISpellSelectorSlotPresenterFactory<SelectorSpellSlotPresenter> {
        
        public SelectorSpellSlotPresenter Create(ISelectorSpellSlot model, ISpellSlotUIView view) {
            return new SelectorSpellSlotPresenter(model, view);
        }
    }
}