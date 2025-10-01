using System;
using System.Data;
using ObservableCollections;
using R3;
using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Manager.Interface;
using Teiwas.Script.Spell.Manager.Module.Interface;
using Teiwas.Script.Spell.Slot.Interface;
using UnityEngine;

namespace Teiwas.Script.Spell.Manager.Module {
    [Serializable]
    public class ManagerFillObserver<Slot, Instance> : IManagerFillObserver where Slot : ISpellSlot<Instance> where Instance : ISpellInstance {

        protected readonly ISpellManager<Slot, Instance> m_model;

        protected bool m_isFull = false;

        public bool IsFull => m_isFull;

        protected CompositeDisposable m_disposable = new CompositeDisposable();

        public ManagerFillObserver(ISpellManager<Slot, Instance> model) {

            m_model = model ?? throw new ArgumentNullException(nameof(model));

            m_disposable = new();

            RegisterObserve();
        }

        public void Dispose() {
            m_disposable?.Dispose();
        }

        protected virtual void RegisterObserve () {

            if (m_disposable is null) {
                m_disposable = new();
            }

            m_disposable.Dispose();

            m_model.Spells
                .ObserveChanged()
                .Subscribe( x => OnElementChanged())
                .AddTo(m_disposable);

            Observable
                .EveryValueChanged(m_model, x => x.Length)
                .Subscribe(x => OnElementChanged())
                .AddTo(m_disposable);

        }

        protected virtual void OnElementChanged() {
            m_isFull = CheckWasFill();
        }

        protected virtual void OnLengthChanged() {
            m_isFull = CheckWasFill();
        }

        protected bool CheckWasFill() {

            Debug.Assert(m_model.Spells.Count > m_model.Length);

            //全スロットの検査、一つでもSlot.IsEmpty = trueならtrueを返す
            foreach (var spell in m_model.Spells) {
                if (spell.Value.IsEmpty is true) {
                    return true;
                }
            }

            return false;
        }
    }
}
