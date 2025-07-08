using Project.Script.Utility;
using Sirenix.OdinInspector;
using Teiwas.Script.Camera;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Script.Installer.Camera {
    public class CameraInstaller : SerializedMonoBehaviour, IInstaller {

        public void Install(IContainerBuilder builder) {

            builder
                .RegisterComponent(ComponentsUtility.GetComponentFromWhole<CameraBrain>(gameObject));
        }
    }
}
