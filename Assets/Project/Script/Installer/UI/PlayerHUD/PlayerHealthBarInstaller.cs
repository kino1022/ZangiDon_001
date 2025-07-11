using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Script.Utility;
using Teiwas.Script.UIControl.PlayerHUD.HealthBar;
using Teiwas.Script.UIControl.PlayerHUD.HealthBar.Interface;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Script.Installer.UI {
    /// <summary>
    /// PlayerのHealthBar関連の依存性のインストールを行うクラス
    /// </summary>
    public class PlayerHealthBarInstaller : IInstaller {

        protected GameObject m_instance;

        public PlayerHealthBarInstaller(GameObject instance) {
            m_instance = instance;
        }

        public void Install(IContainerBuilder builder) {

            builder
                .RegisterComponent(ComponentsUtility.GetComponentFromWhole<IPlayerHealthBarView>(m_instance))
                .As<IPlayerHealthBarView>();

            builder
                .RegisterEntryPoint<PlayerHealthBarPresenter>()
                .As<IPlayerHealthBarPresenter>();
        }
    }
}
