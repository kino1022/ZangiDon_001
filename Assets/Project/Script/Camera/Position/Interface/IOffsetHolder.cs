using UnityEngine;

namespace Project.Script.Camera.Position.Interface {
    /// <summary>
    /// カメラと追従対象の相対距離を管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface IOffsetHolder {
                
        /// <summary>
        /// 追従対象からどの程度の高さを取るか
        /// </summary>
        public float Higher { get; }
        
        /// <summary>
        /// 追従対象からどの程度の距離を取るか
        /// </summary>
        public float Distance { get; }
    }
}