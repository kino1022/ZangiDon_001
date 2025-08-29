using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Spell.Data.Interface;
using Teiwas.Script.Spell.Factory.Interface;
using Teiwas.Script.Spell.Factory.Pattern.Interface;
using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Instance.Module;
using Teiwas.Script.Spell.Instance.Module.Interface;
using VContainer;
using Random = UnityEngine.Random;

namespace Teiwas.Script.Spell.Factory {
    [Serializable]
    public abstract class ASpellFactory<Data,Instance,Pattern> : ISpellFactory<Data,Instance> 
        where Data : ISpellData 
        where Instance : ISpellInstance 
        where Pattern : ISpellLotteryPattern<Data> 
    {
        [OdinSerialize, LabelText("パターン供給クラス")]
        protected Pattern m_pattern;

        protected IObjectResolver m_resolver;

        protected ASpellFactory(IObjectResolver resolver) {
            m_resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        public virtual void Start() {
            m_pattern = m_resolver.Resolve<Pattern>() 
                        ?? throw new NullReferenceException();
        }

        public virtual void Dispose() {
            
        }

        public abstract Instance Create();
        
        protected virtual IAmountCounter CreateCounter(ISpellData data) {
            return new AmountCounter(data.MaxAmount);
        }

    }
}
