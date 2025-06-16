using Project.Script.UIControl.PlayerHUD;
using Project.Script.UIControl.PlayerHUD.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Script.LTScope.GameManager {
    
    public class GameSceneLifeTimeScope : LifetimeScope {
        
        [SerializeField, OdinSerialize, LabelText("PlayerHUDのLifeTimeScope")]
        protected VContainer.Unity.LifetimeScope m_playerHUD;
        
        protected override void Configure(IContainerBuilder builder) {
            
            
            builder.Register<IPlayerHUDFactory, PlayerHUDFactory>(Lifetime.Singleton)
                .WithParameter(m_playerHUD);
            
        }
    }
}