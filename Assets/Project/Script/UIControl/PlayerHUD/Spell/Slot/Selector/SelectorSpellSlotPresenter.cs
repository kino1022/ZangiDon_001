using Project.Script.UIControl.PlayerHUD.Spell.Slot;
using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Slot.Selector.Interface;

namespace Teiwas.Script.UIControl.PlayerHUD.Spell.Slot.Selector {
    public class SelectorSpellSlotPresenter : ASpellSlotPresenter<ISelectorSpellSlot, ISpellInstance> , ISelectorSpellSlotPresenter {

        public SelectorSpellSlotPresenter(ISelectorSpellSlot model, ISpellSlotUIView view) : base(model, view) {
            
        }
    }
}