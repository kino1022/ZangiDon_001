using System.Collections.Generic;
using ObservableCollections;
using UnityEngine;

namespace Teiwas.Script.Character.Group.Interface {
    /// <summary>
    /// GroupごとにEntityを管理するクラスに約束するインターフェース
    /// </summary>
    public interface IGroupEntityManager {

        public IReadOnlyObservableDictionary<IGroup, List<GameObject>> GroupEntity { get; }

    }
}
