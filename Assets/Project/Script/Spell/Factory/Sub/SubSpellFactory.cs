using System;
using Teiwas.Script.Spell.Data.Sub.Interface;
using Teiwas.Script.Spell.Factory.Interface;
using Teiwas.Script.Spell.Factory.Pattern.Sub.Interface;
using Teiwas.Script.Spell.Factory.Sub.Interface;
using Teiwas.Script.Spell.Instance.Sub;
using Teiwas.Script.Spell.Instance.Sub.Insterface;
using VContainer;

namespace Teiwas.Script.Spell.Factory.Sub {
    [Serializable]
    public class SubSpellFactory 
        : ASpellFactory<ISubSpellData,ISubSpellInstance,ISubSpellLotteryPattern>, 
            ISubSpellFactory 
    {

        [Inject]
        public SubSpellFactory(IObjectResolver resolver) : base(resolver) { }
        
        public override ISubSpellInstance Create() {
            var data = m_pattern.GetCreateData();
            var counter = CreateCounter(data);

            return new SubSpellInstance(
                data.PreCast,
                data.PostCast,
                data.Select,
                data.Contexts,
                data.Sprite,
                data.SpellName,
                counter
                );
        }
    }
}