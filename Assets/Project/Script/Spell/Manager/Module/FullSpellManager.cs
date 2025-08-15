using System;
using System.Collections.Generic;
using System.Linq;
using ObservableCollections;
using R3;
using Teiwas.Script.Spell.Manager.Interface;
using Teiwas.Script.Spell.Manager.Module.Interface;
using Teiwas.Script.Spell.Slot.Interface;

namespace Teiwas.Script.Spell.Manager.Module {
    
    public class FullSpellManager<S> : IFullSpellManager where S : ISpellSlot {

        protected bool m_isFull;

        public bool IsFull => m_isFull;

        protected CompositeDisposable m_disposable;

        protected ISpellManager<S> m_manager;

        public FullSpellManager(ISpellManager<S> manager) {
            m_manager = manager
                        ?? throw new ArgumentNullException($"{GetType().Name}の初期化の際に与えられたISpellManagerがnullでした");

            RegisterObserveIsFull(m_manager);
        }

        public void Dispose() {
            m_disposable.Dispose();
        }

        protected void RegisterObserveIsFull(ISpellManager<S> manager) {
            m_disposable.Dispose();
            m_disposable = new CompositeDisposable();

            m_manager.Spells
                .ObserveChanged()
                .Subscribe(x => OnChangeSpells())
                .AddTo(m_disposable);
        }

        protected void OnChangeSpells() {
            if(m_manager.Spells.Count >= m_manager.Length) {
                m_isFull = true;
            }
            else {
                m_isFull = false;
            }
        }
    }
}
