using Project.Script.Bullet.Range;
using Project.Script.Bullet.Range.Interface;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Project.Script.Scope {
    public class BulletLifeTimeScope : LifetimeScope {

        protected override void Configure(IContainerBuilder builder) {
            
            //自己をオブジェクトとして登録
            builder.RegisterInstance(this.gameObject).As<GameObject>();
            
            //弾丸の距離管理オブジェクトを登録してインスタンス
            builder.RegisterEntryPoint<BulletRangeCounter>().As<IRangeCounter>();
            
        }
        
    }
}