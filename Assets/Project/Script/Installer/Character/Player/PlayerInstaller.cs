using Project.Script.LockManage;
using Project.Script.Utility;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Script.Installer.Character.Player {
    public class PlayerInstaller : CharacterInstaller {
        public override void Install(IContainerBuilder builder) {

            base.Install(builder);

            builder
                .RegisterInstance(ComponentsUtility.GetComponentFromWhole<ILockTargetHolder>(this.gameObject))
                .As<ILockTargetHolder>();

            builder
                .RegisterComponent(ComponentsUtility.GetComponentFromWhole<ITargetContextHolder>(this.gameObject))
                .As<ITargetContextHolder>();

            new RuneReferenceInstaller(this.gameObject).Install(builder);

            new ShooterReferenceInstaller(this.gameObject).Install(builder);
        }
    }
}
