using System.Runtime.Serialization;
using Project.Script.UIControl.PlayerHUD.Interface;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Script.UIControl.PlayerHUD {
    public class PlayerHUDFactory : IPlayerHUDFactory {
        
        protected IObjectResolver m_container;
        
        protected LifetimeScope m_scope;

        public PlayerHUDFactory(IObjectResolver container , LifetimeScope scope) {
            m_container = container;
            m_scope = scope;
        }

        public void Create(GameObject player) {
        }
    }
}