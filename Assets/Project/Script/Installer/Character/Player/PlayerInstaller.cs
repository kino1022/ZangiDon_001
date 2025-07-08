using Project.Script.LockManage;
using Project.Script.Utility;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Script.Installer.Character.Player {
    public class PlayerInstaller : CharacterInstaller {
        public override void Install(IContainerBuilder builder) {

            base.Install(builder);

            builder
                .RegisterInstance(ComponentsUtility.GetComponentFromWhole<ILockTargetHolder>(gameObject))
                .As<ILockTargetHolder>();

            builder
                .RegisterComponent(ComponentsUtility.GetComponentFromWhole<ITargetContextHolder>(gameObject))
                .As<ITargetContextHolder>();

            new RuneReferenceInstaller(gameObject).Install(builder);

            new ShooterReferenceInstaller(gameObject).Install(builder);
        }
    }
}
