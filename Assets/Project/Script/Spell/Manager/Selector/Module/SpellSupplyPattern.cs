using System;
using Sirenix.OdinInspector;
using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Manager.Selector.Module.Interface;
using Teiwas.Script.Spell.Manager.Supplier.Interface;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace Teiwas.Script.Spell.Manager.Selector.Module {
    /// <summary>
    ///
    /// </summary>
    public class SpellSupplyPattern : ISpellSupplyPattern {

        [SerializeField, LabelText("メインスペルの供給率"), ProgressBar(0.0f,100.0f)]
        protected float m_mainSupplyRate = 100.0f;

        protected ISpellSupplier m_supplier;

        protected IObjectResolver m_resolver;

        public SpellSupplyPattern(IObjectResolver resolver) {
            m_resolver = resolver ?? throw new NullReferenceException();
        }

        public void Start() {
            m_supplier = m_resolver.Resolve<ISpellSupplier>() ?? throw new NullReferenceException();
        }

        public void Dispose() {

        }

        public ISpellInstance Supply() {
            if(Random.Range(0.0f, 100.0f) > m_mainSupplyRate) {
                return m_supplier.SupplyMain();
            }
            return m_supplier.SupplySub();
        }
    }
}
