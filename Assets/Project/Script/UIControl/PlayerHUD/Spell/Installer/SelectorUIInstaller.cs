using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.UIControl.PlayerHUD.Spell.Selector.Interface;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Script.UIControl.PlayerHUD.Spell.Installer {
    public class SelectorUIInstaller : SerializedMonoBehaviour , IInstaller {

        [OdinSerialize] protected ISpellSelectorPresenter m_persenter;
        
        [OdinSerialize] protected ISpellSelectorView m_view;

        public void Install(IContainerBuilder builder) {

            builder
                .RegisterInstance(m_persenter)
                .As<ISpellSelectorPresenter>();

            builder
                .RegisterInstance(m_view)
                .As<ISpellSelectorView>();
        }
    }
}
