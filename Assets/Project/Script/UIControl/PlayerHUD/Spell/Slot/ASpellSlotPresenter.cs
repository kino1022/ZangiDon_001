using R3;
using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Slot.Interface;
using Teiwas.Script.UIControl.PlayerHUD.Spell.Slot;

namespace Project.Script.UIControl.PlayerHUD.Spell.Slot {
    /// <summary>
    /// SpellSlotに対するMVPパターンのPresenterに当たるクラスに対して約束するインターフェース
    /// </summary>
    /// <typeparam name="Slot"></typeparam>
    /// <typeparam name="Instance"></typeparam>
    public abstract class ASpellSlotPresenter<Slot, Instance> : ISpellSlotPresenter<Slot, Instance>
        where Slot : ISpellSlot<Instance> where Instance : ISpellInstance 
    {
        protected Slot m_model;
        
        protected ISpellSlotUIView m_view;
        
        protected CompositeDisposable m_disposable;

        protected ASpellSlotPresenter(Slot model, ISpellSlotUIView view) {
            
        }

        public void Start() {
            
        }

        public void Dispose() {
            
        }
        
    }
}