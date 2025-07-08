using System.Collections.Generic;
using Teiwas.Script.Installer.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using VContainer.Unity;

namespace Teiwas.Script.Installer {
    public class InstallerList : SerializedMonoBehaviour , IInstallerList {

        [OdinSerialize, LabelText("インストーラー")]
        protected List<IInstaller> m_list;

        public List<IInstaller> List => m_list;


    }
}
