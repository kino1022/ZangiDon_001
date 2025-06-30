using System.Collections.Generic;
using Project.Script.Bullet.Range;
using Project.Script.Bullet.Range.Interface;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Project.Script.Scope {
    public class BulletLifeTimeScope : LifetimeScope {

        protected override void Configure(IContainerBuilder builder) {

            builder.Register<BulletRangeCounter>(Lifetime.Scoped).As<IRangeCounter>();

        }
        
    }
}