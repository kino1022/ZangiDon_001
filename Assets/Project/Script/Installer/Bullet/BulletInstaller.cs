using Project.Script.Bullet.Range;
using Project.Script.Bullet.Range.Interface;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Script.Installer.Bullet {
    public class BulletInstaller : SerializedMonoBehaviour , IInstaller {


        public void Install(IContainerBuilder builder) {

            builder.RegisterInstance(this.gameObject).As<GameObject>();

            builder.RegisterEntryPoint<BulletRangeCounter>().As<IRangeCounter>();

        }

    }
}
