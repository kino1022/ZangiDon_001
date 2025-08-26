using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Spell.Data.Main.Interface;
using Teiwas.Script.Spell.Data.Sub.Interface;
using Teiwas.Script.Spell.Factory.Interface;
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
        protected ISpellFactory<IMainSpellData, IMainSpellInstance> m_main;
        [OdinSerialize]
        protected ISpellFactory<ISubSpellData, ISubSpellInstance> m_sub;
        
        public void Install(IContainerBuilder builder) {
            
            builder
                .RegisterInstance(m_main)
                .As<ISpellFactory<IMainSpellData, IMainSpellInstance>>();
            
            builder
                .RegisterInstance(m_sub)
                .As<ISpellFactory<ISubSpellData, ISubSpellInstance>>();
            
        }
    }
}