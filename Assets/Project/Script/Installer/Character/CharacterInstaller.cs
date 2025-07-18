using System;
using Project.Script.Bullet.Instance.Factory;
using Project.Script.Utility;
using Sirenix.OdinInspector;
using Teiwas.Script.Asset.Status.Health.Interface;
using Teiwas.Script.Bullet.Instance.Interface;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Script.Installer.Character {

    [Serializable]
    public class CharacterInstaller : SerializedMonoBehaviour , IInstaller {

        public virtual void Install(IContainerBuilder builder) {

            builder
                .RegisterComponent(ComponentsUtility.GetComponentFromWhole<IHealth>(this.gameObject))
                .As<IHealth>();

            builder
                .RegisterComponent(ComponentsUtility.GetComponentFromWhole<IMaxHealth>(gameObject))
                .As<IMaxHealth>();

            //弾丸生成クラスのレジスト
            builder
                .Register<IBulletFactory, BulletFactory>(Lifetime.Singleton)
                .As<IBulletFactory>();

        }
    }

}
