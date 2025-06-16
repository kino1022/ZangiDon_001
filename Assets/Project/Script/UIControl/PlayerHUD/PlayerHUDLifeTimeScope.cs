using Project.Script.UIControl.PlayerHUD.HealthBar;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Script.UIControl.PlayerHUD {
    public class PlayerHUDLifeTimeScope : LifetimeScope {
        
        protected override void Configure(IContainerBuilder builder) {
            builder.Register<PlayerHealthBarInstaller>(lifetime: Lifetime.Scoped);
        }
        
    }
}