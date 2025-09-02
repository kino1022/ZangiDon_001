using Project.Script.Utility;
using Sirenix.OdinInspector;
using Teiwas.Script.Bullet.Context.Manager.Interface;
using Teiwas.Script.Spell.Manager.Sub;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Script.Spell.Installer {
    public class SubManagerInstaller : SerializedMonoBehaviour, IInstaller {


        public void Install(IContainerBuilder builder) {

            builder
                .RegisterComponent(ComponentsUtility.GetComponentFromWhole<ISubSpellManager>(gameObject))
                .As<ISubSpellManager>();

            //サブ効果の弾丸に対する影響を管理するクラス
            builder
                .RegisterComponent(ComponentsUtility.GetComponentFromWhole<IBulletContextManager>(gameObject))
                .As<IBulletContextManager>();

        }
    }
}
