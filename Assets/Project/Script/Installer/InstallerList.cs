using System.Collections.Generic;
using Project.Script.Installer.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using VContainer.Unity;

namespace Project.Script.Installer {
    public class InstallerList : SerializedMonoBehaviour , IInstallerList {
        
        [OdinSerialize, LabelText("インストーラー")]
        protected List<IInstaller> m_list;
        
        public List<IInstaller> List => m_list;
        
        
    }
}