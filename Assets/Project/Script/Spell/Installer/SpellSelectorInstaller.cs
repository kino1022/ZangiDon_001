using Project.Script.Utility;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Spell.Manager.Container.Interface;
using Teiwas.Script.Spell.Manager.Selector.Interface;
using Teiwas.Script.Spell.Manager.Supplier.Interface;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Script.Spell.Installer {
    
    public class SpellSelectorInstaller : SerializedMonoBehaviour , IInstaller {

        [OdinSerialize, LabelText("")] 
        protected ISelectSpellContainer m_container;
        
        [OdinSerialize, LabelText("")] 
        protected ISpellSupplier m_supplier;
        

        public void Install(IContainerBuilder builder) {

            builder
                .RegisterComponent(ComponentsUtility.GetComponentFromWhole<ISpellSelector>(gameObject))
                .As<ISpellSelector>();
            
            builder.RegisterInstance(m_supplier).As<ISpellSupplier>();
            
            builder.RegisterInstance(m_container).As<ISelectSpellContainer>();
        }
    }
}