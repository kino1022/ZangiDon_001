using Teiwas.Script.Camera.Interface;
using UnityEngine;

namespace Teiwas.Script.Camera.Position.Interface {
    /// <summary>
    /// カメラの位置を管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface ICameraPositionHolder : ICameraControlElement {
        
        /// <summary>
        /// カメラの取るべき位置
        /// </summary>
        public Vector3 Position { get; }
        
        public ICameraOffSetHolder OffSet { get; }
        
    }
}