using Project.Script.Utility;
using Teiwas.Script.GameManager.Interface;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Script.Installer.GameManager {
    public class EntityManagerInstaller : IInstaller {
        protected GameObject m_manager;

        public EntityManagerInstaller(GameObject manager) {
            m_manager = manager;
        }

        public void Install(IContainerBuilder builder) {

            builder
                .RegisterComponent(ComponentsUtility.GetComponentFromWhole<IEntityManager>(m_manager))
                .As<IEntityManager>();
        }
    }
}
