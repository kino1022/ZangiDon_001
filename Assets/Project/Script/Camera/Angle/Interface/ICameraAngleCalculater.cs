using UnityEngine;

namespace Teiwas.Script.Camera.Angle.Interface {
    /// <summary>
    /// カメラのアングルを計算するクラスに対して約束するインターフェース
    /// </summary>
    public interface ICameraAngleCalculater {
        /// <summary>
        /// アングルを計算するメソッド
        /// </summary>
        /// <returns></returns>
        public Quaternion CalculateAngle();
    }
}