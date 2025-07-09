using UnityEngine;
using VContainer;

namespace Teiwas.Script.Spawner.Position.Interface {
    /// <summary>
    /// スポナーからスポーンする位置を管理するクラスに約束するインターフェース
    /// </summary>
    public interface ISpawnPositionManager {

        /// <summary>
        /// 必要なオブジェクトやコンポーネントを取得するための初期化処理
        /// </summary>
        /// <param name="resolver"></param>
        /// <param name="spawner"></param>
        public void Initialize(IObjectResolver resolver, GameObject spawner);

        /// <summary>
        /// スポーンする位置を計算して返すメソッド
        /// </summary>
        /// <returns></returns>
        public Vector3 Position();
    }
}
