using Project.Script.Bullet.Homing;
using Project.Script.Bullet.Homing.Interface;
using Project.Script.Bullet.Interface;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Script.Bullet.Container {
    public class BulletLifeTimeScope : LifetimeScope {
        
        [SerializeField] protected IBulletDataHolder m_dataHolder;
        
        protected override void Configure(IContainerBuilder builder) {
            
            builder.RegisterComponent(m_dataHolder);
        }
    }
}