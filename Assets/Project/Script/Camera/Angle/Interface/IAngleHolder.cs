using UnityEngine;

namespace Project.Script.Camera.Angle.Interface {
    /// <summary>
    /// カメラの取るべきアングルを管理するクラスに約束するインターフェース
    /// </summary>
    public interface IAngleHolder {
        /// <summary>
        /// 取るべきアングル
        /// </summary>
        public Quaternion Angle { get; }
    }
}