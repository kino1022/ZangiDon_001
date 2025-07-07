using ObservableCollections;
using UnityEngine;

namespace Teiwas.Script.GameManager.Interface {
    public interface IEntityManager {
        /// <summary>
        /// 現在存在している敵味方のリスト
        /// </summary>
        /// <value></value>
        public IReadOnlyObservableList<GameObject> Entitys { get; }
    }
}
