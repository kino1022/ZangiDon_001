using Sirenix.OdinInspector;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Script.Installer.GameManager {
    public class GameManagerInstaller : SerializedMonoBehaviour, IInstaller {
        public void Install(IContainerBuilder builder) {
            new EntityManagerInstaller(gameObject).Install(builder);
        }
    }
}
