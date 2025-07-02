using UnityEngine;

namespace Project.Script.Camera.Position.Interface {
    /// <summary>
    /// カメラの取るべき位置を管理するクラスに対して与えるインターフェース
    /// </summary>
    public interface IPositionHolder {
        /// <summary>
        /// カメラの取るべき位置
        /// </summary>
        public Vector3 Position { get; }
    }
}