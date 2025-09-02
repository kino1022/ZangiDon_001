using Project.Script.Utility;
using Sirenix.OdinInspector;
using Teiwas.Script.Spell.Manager.Main.Interface;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Script.Spell.Installer {
    /// <summary>
    /// MainSpellManager周りのシステムのインストールをするためのインストーラー
    /// </summary>
    public class MainManagerInstaller : SerializedMonoBehaviour, IInstaller {

        public void Install(IContainerBuilder builder) {
            builder
                .RegisterComponent(ComponentsUtility.GetComponentFromWhole<IMainSpellManager>(gameObject))
                .As<IMainSpellManager>();
        }
    }
}
