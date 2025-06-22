using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Target.Interface;
using UnityEngine;

namespace Teiwas.Script.UIControl.Utility {
    public class PlayerCharacterHolder : SerializedMonoBehaviour, ITargetHolder<GameObject> {
        
        [OdinSerialize, LabelText("プレイヤーのオブジェクト")]
        protected GameObject m_character;
        
        /// <summary>
        /// シーン上にいるプレイヤーのオブジェクトを取得する
        /// </summary>
        /// <returns></returns>
        public GameObject GetTarget() {
            if (m_character == null) {
                var character = GameObject.FindWithTag("Player");

                if (character == null) {
                    Debug.LogError("ゲームシーン上にPlayerのタグをつけているオブジェクトが存在しませんでした");
                    return null;
                }
                
                return character;
            }
            
            return m_character;
        }
    }
}