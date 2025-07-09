using Sirenix.OdinInspector;
using UnityEngine;

namespace Teiwas.Script.Enemy.Data {
    /// <summary>
    /// 生成される敵のデータを管理するクラス
    /// </summary>
    [CreateAssetMenu(menuName = "Project/Enemy/Data")]
    public class EnemyData : SerializedScriptableObject {

        /// <summary>
        /// EnemyのPrefab
        /// </summary>
        public GameObject EnemyPrefab;
    }
}
