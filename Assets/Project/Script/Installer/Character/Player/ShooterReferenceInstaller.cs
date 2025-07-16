using Teiwas.Script.Character.Shoter;
using Project.Script.Utility;
using Teiwas.Script.Bullet.Context.Intetface;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Script.Installer.Character.Player {
    public class ShooterReferenceInstaller : IInstaller {

        protected GameObject m_character;

        public ShooterReferenceInstaller(GameObject character) {
            m_character = character;
        }

        public void Install(IContainerBuilder builder) {

            builder
                .RegisterInstance(ComponentsUtility.GetComponentFromWhole<IBulletContextHolder>(m_character))
                .As<IBulletContextHolder>();

            builder
                .RegisterComponent(ComponentsUtility.GetComponentFromWhole<CharacterMagicShoter>(m_character))
                .As<CharacterMagicShoter>();
        }
    }
}
