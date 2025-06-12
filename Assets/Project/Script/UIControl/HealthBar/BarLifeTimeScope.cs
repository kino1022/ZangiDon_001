using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Script.UIControl.HealthBar
{
    public class BarLifeTimeScope : LifetimeScope
    {

        [OdinSerialize, LabelText("ステータスバーのインスタンス")]
        protected GameObject m_bar;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
        }
    }
}