using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Script.Status {
    /// <summary>
    /// ステータスのデータを保持するクラス
    /// </summary>
    [CreateAssetMenu(menuName = "Project/Status/StatusData",fileName = "StatusData")]
    public class StatusData : ScriptableObject {
        public float InitialValue = 100;
    }
}