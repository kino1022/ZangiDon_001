using Project.Script.Bullet.Instance.Factory;
using Teiwas.Script.Asset.Status.Health.Interface;
using Teiwas.Script.Bullet.Context.Intetface;
using Teiwas.Script.Bullet.Instance.Interface;
using VContainer;
using VContainer.Unity;

namespace DefaultNamespace {
    /// <summary>
    /// ゲーム全体でのDIコンテナ
    /// </summary>
    public class GameLifeTimeScope : LifetimeScope{
        
        protected override void Configure(IContainerBuilder builder) {
            
            //弾丸生成クラスをレジスタ
            builder.Register<IBulletFactory, BulletFactory>(Lifetime.Singleton);
            
            //弾丸の動的性能変化管理クラスをレジスタ
            builder.Register<IBulletContextHolder>(Lifetime.Singleton);

			
        }
    }
}