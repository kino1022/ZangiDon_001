using Project.Script.UIControl.PlayerHUD.Rune.RuneSlot.Sub;
using Project.Script.UIControl.PlayerHUD.Rune.RuneSlot.Sub.Interface;
using Project.Script.Utility;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Script.Installer.UI.PlayerHUD.RuneUI {
    public class SubRuneSlotInstaller : IInstaller {
        
        protected GameObject m_character;

        public SubRuneSlotInstaller(GameObject character) {
            m_character = character;
        }

        public void Install(IContainerBuilder builder) {
            
            builder
                .RegisterInstance
                    (ComponentsUtility.GetComponentFromWhole<ISubRuneSlotView>(m_character))
                .As<ISubRuneSlotView>();
            
            builder.RegisterEntryPoint<SubRuneSlotPresenter>().As<ISubRuneSlotPresenter>();
            
        }
    }
}