using UnityEngine;

namespace Project.Script.Camera.Interface {
    /// <summary>
    /// カメラの位置を管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface IPositionHolder {
        /// <summary>
        /// カメラの位置を取得するメソッド
        /// </summary>
        /// <returns></returns>
        public Vector3 GetPosition();
    }
}