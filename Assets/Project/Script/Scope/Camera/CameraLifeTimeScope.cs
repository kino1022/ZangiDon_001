using Project.Script.Camera.Direction;
using Project.Script.Camera.Direction.Interface;
using Project.Script.Utility;
using Teiwas.Script.UIControl.Utility;
using UnityCommonModule.Target.Interface;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Project.Script.Scope.Camera {
    public class CameraLifeTimeScope : LifetimeScope {

        protected override void Configure(IContainerBuilder builder) {
            
            builder
                .RegisterComponent(ComponentsUtility.GetComponentFromWhole<ITargetHolder<GameObject>>(this.gameObject))
                .As<ITargetHolder<GameObject>>();
            
            builder
                .Register<ITargetDirectionHolder, TargetDirectionManager>(Lifetime.Scoped)
                .WithParameter(this.gameObject);
        }
    }
}