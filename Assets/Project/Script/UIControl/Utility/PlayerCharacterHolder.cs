using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Target.Interface;
using UnityEngine;

namespace Project.Script.UIControl.Utility {
    public class PlayerCharacterHolder : SerializedMonoBehaviour, ITargetHolder<GameObject> {
        
        [OdinSerialize, LabelText("プレイヤーのオブジェクト")]
        protected GameObject m_character;

        public GameObject GetTarget() {
            return m_character;
        }
    }
}