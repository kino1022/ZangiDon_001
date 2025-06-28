using Project.Script.Utility;
using Teiwas.Script.UIControl.PlayerHUD.RuneSelector;
using Teiwas.Script.UIControl.PlayerHUD.RuneSelector.Interface;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Script.Installer.UI.PlayerHUD.RuneUI {
    public class RuneSelectorInstaller : IInstaller {

        protected GameObject m_character;

        public RuneSelectorInstaller(GameObject character) {
            m_character = character;
        }

        public void Install(IContainerBuilder builder) {
            
            
            builder
                .RegisterInstance
                    (ComponentsUtility.GetComponentFromWhole<IRuneSelectorView>(m_character))
                .As<IRuneSelectorView>();
            
            builder.RegisterEntryPoint<RuneSelectorPresenter>().As<IRuneSelectorPresenter>();
            
        }
    }
}