using System.Collections.Generic;
using VContainer.Unity;

namespace Project.Script.Installer.Interface {
    
    public interface IInstallerList {
        public List<IInstaller> List { get; }
    }
    
}