using UnityEngine;

namespace Teiwas.Script.Camera.Position.Interface {
    /// <summary>
    /// 追従対象とターゲットをもとにカメラの位置を計算するクラスに対して約束するインターフェース
    /// </summary>
    public interface ICameraPositionCalculator {
        public Vector3 Calculate();
    }
}