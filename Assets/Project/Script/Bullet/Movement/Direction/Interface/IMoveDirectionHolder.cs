using UnityEngine;

namespace Teiwas.Script.Bullet.Movement.Direction.Interface {
    /// <summary>
    /// 生成物の移動方向を管理するクラスに約束するインターフェース
    /// </summary>
    public interface IMoveDirectionHolder {
        /// <summary>
        /// 移動方向
        /// </summary>
        public Vector3 Direction { get; }
    }
}