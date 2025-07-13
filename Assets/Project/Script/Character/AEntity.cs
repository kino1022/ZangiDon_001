using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Script.Character {

    public abstract class AEntity : SerializedMonoBehaviour {

        [SerializeField, LabelText("このエンティティの実体")]
        protected GameObject m_obj;

        /// <summary>
        /// このEntityの持つゲームオブジェクト
        /// </summary>
        public GameObject Object => m_obj;

        [SerializeField, LabelText("実体の自動取得")]
        protected bool m_autoSetting = true;

        private void Awake() {
            if(m_autoSetting is true || m_obj is null) {
                AutoSettingObject();
            }
        }

        protected virtual void AutoSettingObject() {
            m_obj = gameObject.transform.root.gameObject;
        }
    }
}
