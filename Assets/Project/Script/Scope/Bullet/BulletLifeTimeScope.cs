using System.Collections.Generic;
using Project.Script.Bullet.Range;
using Project.Script.Bullet.Range.Interface;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Project.Script.Scope {
    public class BulletLifeTimeScope : LifetimeScope {
        
        protected List<IInstaller> m_installer = new List<IInstaller>();

        protected override void Configure(IContainerBuilder builder) {

            foreach (var installer in m_installer) {
                installer.Install(builder);
            }
            
        }

        public void SetInstaller(IInstaller installer) {
            m_installer.Add(installer);
        }
    }
}