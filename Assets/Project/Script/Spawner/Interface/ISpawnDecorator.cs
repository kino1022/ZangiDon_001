using System.Runtime.Serialization;
using UnityEngine;
using VContainer;

namespace Teiwas.Script.Spawner.Interface {
    /// <summary>
    /// スポーンしたエンティティに対してなんらかの処理を及ぼすクラスに対して約束するインターフェース
    /// </summary>
    public interface ISpawnDecorator {
        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="resolver"></param>
        /// <param name="spawner"></param>
        public void Initialize(IObjectResolver resolver, GameObject spawner);

        /// <summary>
        /// スポーンしたエンティティに対して修飾するメソッド
        /// </summary>
        /// <param name="entity"></param>
        public void Decorate(GameObject entity);
    }
}
