using UnityEngine;

namespace Project.Script.Camera.Interface {
    /// <summary>
    /// カメラの向きを管理するクラスに約束するインターフェース
    /// </summary>
    public interface IAngleHolder {
        /// <summary>
        /// カメラのアングルを管理するメソッド
        /// </summary>
        /// <returns></returns>
        public Quaternion GetAngle();
    }
}