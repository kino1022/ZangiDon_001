using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Script.Player {
    /// <summary>
    /// Playerに割り当てられるキャラクターの代名詞コンポーネント
    /// </summary>
    public class Player : SerializedMonoBehaviour {

        [SerializeField, LabelText("")]
        public GameObject Object;

        private void Awake() {
            if(Object is null) {
                Object = gameObject.transform.root.gameObject;
            }
        }
    }
}
