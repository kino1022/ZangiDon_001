using UnityEngine;
using VContainer;

namespace Teiwas.Script.Bullet.Movement.Direction.Pattern {
    /// <summary>
    /// 移動方向変化のパターンを管理するクラス
    /// </summary>
    public interface IDirectionPattern {
        
        public Vector3 Direction { get; }
        
        /// <summary>
        /// パターンの変化を開始する
        /// </summary>
        /// <param name="resolver"></param>
        public void StartControl (IObjectResolver resolver, GameObject self);
            
    }
}