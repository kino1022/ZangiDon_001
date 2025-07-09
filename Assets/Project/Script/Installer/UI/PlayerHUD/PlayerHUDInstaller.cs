using Project.Script.Installer.UI.PlayerHUD.RuneUI;
using Sirenix.OdinInspector;
using Teiwas.Script.Installer.UI;
using VContainer;
using VContainer.Unity;

namespace Project.Script.Installer.UI.PlayerHUD {
    public class PlayerHUDInstaller : SerializedMonoBehaviour , IInstaller {

        public void Install(IContainerBuilder builder) {

            new RuneSelectorInstaller(this.gameObject).Install(builder);

            new MainRuneSlotInstaller(this.gameObject).Install(builder);

            new SubRuneSlotInstaller(this.gameObject).Install(builder);

            new PlayerHealthBarInstaller(gameObject).Install(builder);
            
        }
        
    }
}