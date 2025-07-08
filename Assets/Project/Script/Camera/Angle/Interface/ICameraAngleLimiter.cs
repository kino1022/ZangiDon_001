using UnityEngine;

namespace Teiwas.Script.Camera.Angle.Interface {
    /// <summary>
    /// カメラのアングル限界を管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface ICameraAngleLimiter {
        
        /// <summary>
        /// 与えられたオイラー角に対してアングル限界を適用する
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Vector3 ApplyLimit(Vector3 value);
    }
}