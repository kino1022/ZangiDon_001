using Project.Script.UIControl.PlayerHUD.Spell;
using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Manager.Selector.Interface;
using Teiwas.Script.Spell.Slot.Selector.Interface;
using Teiwas.Script.UIControl.PlayerHUD.Spell.Selector.Interface;
using Teiwas.Script.UIControl.PlayerHUD.Spell.Slot;
using VContainer;

namespace Teiwas.Script.UIControl.PlayerHUD.Spell.Selector {
    
    public class SpellSelectorPresenter : ASpellManagerPresenter<
        ISpellSelectorView,ISpellSelector,ISelectorSpellSlot,ISpellInstance,ISpellSlotPresenter<ISelectorSpellSlot, ISpellInstance>
    > {

        public SpellSelectorPresenter(IObjectResolver resolver) : base(resolver) {
            
        }
        protected override void InitializeSlotPresenter() {
            
        }
    }
}