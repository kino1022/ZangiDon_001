using Project.Script.UIControl.PlayerHUD.Rune.RuneSlot.Main;
using Project.Script.UIControl.PlayerHUD.Rune.RuneSlot.Main.Interface;
using Project.Script.Utility;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Script.Installer.UI.PlayerHUD.RuneUI {
    public class MainRuneSlotInstaller : IInstaller {

        protected GameObject m_character;
        
        public MainRuneSlotInstaller(GameObject character) {
            m_character = character;
        }

        public void Install(IContainerBuilder builder) {
            
            
            builder
                .RegisterInstance
                    (ComponentsUtility.GetComponentFromWhole<IMainRuneSlotView>(m_character))
                .As<IMainRuneSlotView>();
            
            builder.RegisterEntryPoint<MainRuneSlotPresenter>().As<IMainRuneSlotPresenter>();
        }
    }
}