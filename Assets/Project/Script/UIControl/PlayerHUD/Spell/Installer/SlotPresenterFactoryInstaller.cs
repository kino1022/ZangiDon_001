using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Slot.Selector.Interface;
using Teiwas.Script.UIControl.PlayerHUD.Spell.Slot;
using Teiwas.Script.UIControl.PlayerHUD.Spell.Slot.Factory.Interface;
using Teiwas.Script.UIControl.PlayerHUD.Spell.Slot.Selector;
using Teiwas.Script.UIControl.PlayerHUD.Spell.Sub.Interface;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Script.UIControl.PlayerHUD.Spell.Installer {
    [CreateAssetMenu(menuName = "Project/PlayerHUD/Spell/Config/SlotPresenterFactory")]
    public class SlotPresenterFactoryInstaller : SerializedScriptableObject , IInstaller {
        
        [OdinSerialize]
        protected ISpellSelectorSlotPresenterFactory<ISelectorSpellSlotPresenter> m_selectorslotPresenter;
        
        [OdinSerialize]
        protected IMainSpellSlotPresenterFactory<IMainSpellSlotPresenter> m_mainslotPresenter;
        
        [OdinSerialize]
        protected ISubSpellSlotPresenterFactory<ISubSpellSlotPresenter> m_subslotPresenter;

        public void Install(IContainerBuilder builder) {
        }
    }
}
