using VContainer;
using VContainer.Unity;

namespace Project.Script.Bullet.Homing {
    
    public class HomingInstaller : IInstaller {
        public void Install(VContainer.IContainerBuilder builder) {
            
            builder.Register<HomingDirectionModule>(Lifetime.Scoped);
            builder.Register<OnInitializeHomingModule>(Lifetime.Scoped);
            
            
        }
    }
}