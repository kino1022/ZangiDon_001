using System;
using R3;
using Teiwas.Script.Spell.Slot.Interface;
using Teiwas.Script.UIControl.PlayerHUD.Spell.Slot.Presenter.Interface;
using Teiwas.Script.UIControl.PlayerHUD.Spell.Slot.View.Interface;

namespace Teiwas.Script.UIControl.PlayerHUD.Spell.Slot.Presenter {
    [Serializable]
    public class SpellSlotPresenter : ISpellSlotPresenter {

        protected ISpellSlot m_model;

        protected ISpellSlotView m_view;

        protected CompositeDisposable m_disposable;


        public SpellSlotPresenter(ISpellSlot model, ISpellSlotView view) {

            m_model = model ?? throw new ArgumentNullException();
            m_view = view ?? throw new ArgumentNullException();

        }

        public void Start() {

        }

        public void Dispose() {

        }

        protected virtual void RegisterChangeModel() {

            m_disposable?.Dispose();

            m_disposable = new();

            Observable
                .EveryValueChanged(m_model, x => x.IsEmpty)
                .Subscribe()
                .AddTo(m_disposable);
        }
    }
}
