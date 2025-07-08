using Project.Script.Utility;
using Teiwas.Script.Rune.Manager.Interface;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Script.Installer.Character.Player {
    /// <summary>
    /// ルーンシステム関連の依存性を注入するIInstaller
    /// </summary>
    public class RuneReferenceInstaller : IInstaller {

        protected GameObject m_character;

        public RuneReferenceInstaller(GameObject character) {
            m_character = character;
        }

        public void Install(IContainerBuilder builder) {

            builder
                .RegisterInstance(ComponentsUtility.GetComponentFromWhole<IRuneSelector>(m_character))
                .As<IRuneSelector>();

            builder
                .RegisterInstance(ComponentsUtility.GetComponentFromWhole<IMainRuneSlot>(m_character))
                .As<IMainRuneSlot>();

            builder
                .RegisterInstance(ComponentsUtility.GetComponentFromWhole<ISubRuneSlot>(m_character))
                .As<ISubRuneSlot>();
        }


    }
}
