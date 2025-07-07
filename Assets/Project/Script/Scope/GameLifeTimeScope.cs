using System.Collections.Generic;
using System.ComponentModel;
using Project.Script.Installer;
using Project.Script.Installer.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Project.Script.Scope {
    public class GameLifeTimeScope : LifetimeScope {

        [SerializeField, LabelText("使用するインストーラ")]
        protected InstallerList m_list;

        protected override void Configure(IContainerBuilder builder) {



            InstallFromInstaller(builder);
        }

        protected void InstallFromInstaller(IContainerBuilder builder) {

            if(m_list.List.Count == 0) {
                Debug.Log("登録されたIInstallerが0なので処理を終了します");
                return;
            }

            foreach(var installer in m_list.List) {
                installer.Install(builder);
            }

        }
    }
}
