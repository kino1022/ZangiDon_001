using System;
using UnityEngine;
using VContainer;

namespace Teiwas.Script.Bullet.Movement.Direction.Pattern {
    /// <summary>
    /// テスト用のIMoveDirectionPattern
    /// </summary>
    [Serializable]
    public class DebugDirectionPattern : IDirectionPattern {

        [SerializeField] protected Vector3 m_direction = Vector3.zero;
        
        public Vector3 Direction => m_direction.normalized;

        
        public void StartControl(IObjectResolver resolver, GameObject self) {
            
            if (m_direction == Vector3.zero) {
                Debug.Log("物体の運動方向が設定されていません");
                return;
            }
            
        }
    }
}