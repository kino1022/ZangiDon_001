using UnityEngine;

namespace Project.Script.Bullet.Homing.Interface {
    /// <summary>
    /// 誘導の動作を実行するクラスに約束するインターフェース
    /// </summary>
    public interface IHomingExecutor {
        /// <summary>
        /// 誘導の動作を実行するメソッド
        /// </summary>
        /// <param name="bullet">弾丸のゲームオブジェクト</param>
        public void Execute (GameObject bullet);
    }
}