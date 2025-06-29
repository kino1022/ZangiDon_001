using Project.Script.LockManage;
using Project.Script.Utility;
using Teiwas.Script.Bullet.Context.Intetface;
using Teiwas.Script.Bullet.Instance.Interface;
using Teiwas.Script.Rune.Manager.Interface;
using VContainer;
using VContainer.Unity;

namespace Project.Script.Installer.Character.Player {
    public class PlayerInstaller : CharacterInstaller {
        public override void Install(IContainerBuilder builder) {
            
            base.Install(builder);
            
            builder
                .RegisterInstance(ComponentsUtility.GetComponentFromWhole<ILockTargetHolder>(this.gameObject))
                .As<ILockTargetHolder>();
            
            new RuneReferenceInstaller(this.gameObject).Install(builder);
            
            new ShooterReferenceInstaller(this.gameObject).Install(builder);
        }
    }
}