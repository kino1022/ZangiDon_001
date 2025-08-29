using System;
using Teiwas.Script.Spell.Data.Main.Interface;
using Teiwas.Script.Spell.Factory.Main.Interface;
using Teiwas.Script.Spell.Factory.Pattern.Main.Interface;
using Teiwas.Script.Spell.Instance.Main;
using Teiwas.Script.Spell.Instance.Main.Interface;
using Teiwas.Script.Spell.Instance.Module;
using VContainer;

namespace Teiwas.Script.Spell.Factory.Main {
    [Serializable]
    public class MainSpellFactory :
        ASpellFactory<IMainSpellData, IMainSpellInstance, IMainSpellLotteryPattern> , 
        IMainSpellFactory
    {

        [Inject]
        public MainSpellFactory(IObjectResolver resolver) : base(resolver) {
            
        }

        public override IMainSpellInstance Create() {

            var data = m_pattern.GetCreateData();
            var counter = CreateCounter(data);

            return new MainSpellInstance(
                data.Sprite,
                data.SpellName,
                counter,
                data.CastAction.OnCast
                );
            
        }
    }
}