
using VContainer;
using VContainer.Unity;

namespace Teiwas.Project.Script.Scope {
    /// <summary>
    /// ゲーム全体でのDIコンテナ
    /// </summary>
    public class RootLifeTimeScope : LifetimeScope , IInitializable {
        
        public void Initialize() {
            DontDestroyOnLoad(this.gameObject);
        }
        
        protected override void Configure(IContainerBuilder builder) {
            
        }
    }
}