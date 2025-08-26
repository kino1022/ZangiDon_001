using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Instance.Main.Interface;
using Teiwas.Script.Spell.Instance.Sub.Insterface;
using Teiwas.Script.Spell.Slot.Factory.Interface;
using Teiwas.Script.Spell.Slot.Main.Interface;
using Teiwas.Script.Spell.Slot.Selector.Interface;
using Teiwas.Script.Spell.Slot.Sub.Instance;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Script.Spell.Installer {
    [CreateAssetMenu(menuName = "Project/Spell/Config/Installer/SpellSlotFactoryInstaller")]
    public class SpellSlotFactoryInstaller : SerializedScriptableObject , IInstaller {

        [OdinSerialize, LabelText("メインスロット")] 
        protected ISpellSlotFactory<IMainSpellSlot, IMainSpellInstance> m_mainFactory;
        
        [OdinSerialize, LabelText("サブスロット")]
        protected ISpellSlotFactory<ISubSpellSlot,ISubSpellInstance> m_subFactory;
        
        [OdinSerialize, LabelText("セレクタースロット")]
        protected ISpellSlotFactory<ISelectorSpellSlot, ISpellInstance> m_selectorFactory;

        public void Install(IContainerBuilder builder) {
            
            builder
                .RegisterInstance(m_mainFactory)
                .As<ISpellSlotFactory<IMainSpellSlot, IMainSpellInstance>>();
            
            builder
                .RegisterInstance(m_subFactory)
                .As<ISpellSlotFactory<ISubSpellSlot, ISubSpellInstance>>();

            builder
                .RegisterInstance(m_selectorFactory)
                .As<ISpellSlotFactory<ISelectorSpellSlot, ISpellInstance>>();
            
        }
    }
}