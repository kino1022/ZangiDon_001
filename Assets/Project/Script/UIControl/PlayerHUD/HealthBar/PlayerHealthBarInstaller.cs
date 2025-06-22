using System.ComponentModel;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Script.UIControl.PlayerHUD.HealthBar {
    public class PlayerHealthBarInstaller : IInstaller {
        public void Install(IContainerBuilder builder) {
            
            builder.RegisterComponentInHierarchy<PlayerHealthView>();
            builder.Register<PlayerHealthBarPresenter>(Lifetime.Scoped);
            
        }
    }
}