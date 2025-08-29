using System;
using Sirenix.Serialization;
using Teiwas.Script.Spell.Factory.Main.Interface;
using Teiwas.Script.Spell.Factory.Sub.Interface;
using Teiwas.Script.Spell.Instance.Main.Interface;
using Teiwas.Script.Spell.Instance.Sub.Insterface;
using Teiwas.Script.Spell.Manager.Supplier.Interface;
using VContainer;

namespace Teiwas.Script.Spell.Manager.Supplier {
    [Serializable]
    public class SpellSupplier : ISpellSupplier {
        
        protected readonly IObjectResolver m_resolver;
        
        protected IMainSpellFactory m_mainFactory;
        
        protected ISubSpellFactory m_subFactory;
        
        [Inject]
        public SpellSupplier(IObjectResolver resolver) {
            m_resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        public void Start() {
            m_mainFactory = m_resolver.Resolve<IMainSpellFactory>() ?? throw new ArgumentNullException(nameof(m_mainFactory));
            
            m_subFactory = m_resolver.Resolve<ISubSpellFactory>() ?? throw new ArgumentNullException(nameof(m_subFactory));
        }

        public void Dispose() {
            
        }

        public (IMainSpellInstance, ISubSpellInstance) SupplyBath() {
            return (GetMain(), GetSub());
        }

        public IMainSpellInstance SupplyMain() {
            return GetMain();
        }

        public ISubSpellInstance SupplySub() {
            return GetSub();
        }

        protected IMainSpellInstance GetMain() {
            var result = m_mainFactory.Create();
            
            if (result is null) {
                throw new NullReferenceException($"{GetType().Name}に{nameof(m_mainFactory)}から渡されたIMainSpellInstanceがnullでした");
            }
            
            return result;
        }

        protected ISubSpellInstance GetSub() {
            var result = m_subFactory.Create();

            if (result is null) {
                throw new NullReferenceException($"{GetType().Name}に{nameof(m_subFactory)}から渡されたISubSpellInstanceがnullでした");
            }
            
            return result;
        }
    }
}