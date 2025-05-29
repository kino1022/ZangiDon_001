using UnityEngine;

namespace Project.Script.Camera.Interface {
    /// <summary>
    /// カメラのオフセットを管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface IOffsetHolder {
        /// <summary>
        /// オフセットを取得するメソッド
        /// </summary>
        /// <returns></returns>
        public Vector3 GetOffset();
    }
}