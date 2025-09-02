using System;
using System.Collections.Generic;
using System.Linq;
using ObservableCollections;
using R3;
using Sirenix.OdinInspector;
using Teiwas.Script.Bullet.Context.Context;
using Teiwas.Script.Bullet.Context.Intetface;
using Teiwas.Script.Bullet.Context.Manager.Interface;
using Teiwas.Script.Spell.Instance.Sub.Insterface;
using Teiwas.Script.Spell.Manager.Sub;
using UnityEngine;
using VContainer;

namespace Teiwas.Script.Bullet.Context.Manager {
    public class SubSpellContextManager : SerializedMonoBehaviour , IBulletContextManager {

        protected IBulletContext m_context;
        
        protected IObjectResolver m_resolver;

        protected ISubSpellManager m_spellManager;
        
        protected CompositeDisposable m_disposable;
        
        public IBulletContext Context => m_context;

        [Inject]
        public void Construct(IObjectResolver resolver) {
            m_resolver = resolver ?? throw new ArgumentNullException();
        }

        protected void Start() {
            m_spellManager = m_resolver.Resolve<ISubSpellManager>() 
                             ?? throw new ArgumentNullException();
            
            SpellChangeRegister();
        }

        private void SpellChangeRegister() {
            m_disposable = new CompositeDisposable();

            m_spellManager.Spells
                .ObserveChanged()
                .Subscribe(x => OnSpellsChanged())
                .AddTo(m_disposable);
        }

        private void OnSpellsChanged() {
            var contexts = m_spellManager.Spells.Values
                .Select(x => {
                    Debug.Assert(x.Spell is not ISubSpellInstance);
                    return x.Spell;
                })
                .SelectMany(spell => spell.Contexts)
                .ToList();
            
            ApplyContext(contexts);
        }

        private void ApplyContext(List<IBulletContextElement> elements) {
            m_context = new BulletContext(elements);
        } 
    }
}