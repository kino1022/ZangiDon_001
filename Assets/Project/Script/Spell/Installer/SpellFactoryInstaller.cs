using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Spell.Data.Main.Interface;
using Teiwas.Script.Spell.Data.Sub.Interface;
using Teiwas.Script.Spell.Factory.Interface;
using Teiwas.Script.Spell.Factory.Main.Interface;
using Teiwas.Script.Spell.Factory.Pattern.Main.Interface;
using Teiwas.Script.Spell.Factory.Pattern.Sub.Interface;
using Teiwas.Script.Spell.Factory.Sub.Interface;
using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Instance.Main.Interface;
using Teiwas.Script.Spell.Instance.Sub.Insterface;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Script.Spell.Installer {
    [CreateAssetMenu(menuName = "Project/Spell/Config/Installer/SpellFactoryInstaller")]
    public class SpellFactoryInstaller : SerializedScriptableObject , IInstaller {

        [OdinSerialize]
        protected IMainSpellFactory m_main;
        
        [OdinSerialize]
        protected ISubSpellFactory m_sub;
        
        [OdinSerialize]
        protected IMainSpellLotteryPattern m_mainLotteryPattern;
        
        [OdinSerialize]
        protected ISubSpellLotteryPattern m_subLotteryPattern;
        
        public void Install(IContainerBuilder builder) {
            
            builder
                .RegisterInstance(m_main)
                .As<IMainSpellFactory>();
            
            builder
                .RegisterInstance(m_sub)
                .As<ISubSpellFactory>();
            
            builder
                .RegisterInstance(m_mainLotteryPattern)
                .As<IMainSpellLotteryPattern>();
            
            builder
                .RegisterInstance(m_subLotteryPattern)
                .As<ISubSpellLotteryPattern>();
            
        }
    }
}