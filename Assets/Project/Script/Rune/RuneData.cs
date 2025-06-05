using Project.Script.Rune.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Script.Rune {
    /// <summary>
    /// ルーンの発動魔術と効果を管理するクラス
    /// </summary>
    [CreateAssetMenu(menuName = "Project/Rune/Rune")]
    public class RuneData : SerializedScriptableObject {

        [SerializeField] protected string RuneName;

        [SerializeField] protected Image RuneSprite; 
        
        /// <summary>
        /// 一文字目に使用した際の発動する魔術を管理するクラス
        /// </summary>
        [OdinSerialize, SerializeField,LabelText("発動魔術"),InlineEditor(InlineEditorObjectFieldModes.Foldout)] 
        protected ICastable m_cast;
        
        /// <summary>
        /// 二文字目以降に選択された際の付随する効果を管理するクラス
        /// </summary>
        [OdinSerialize, SerializeField,LabelText("補助効果"),InlineEditor(InlineEditorObjectFieldModes.Foldout)]
        protected SupportEffect m_effect;

        public SupportEffect GetSupportEffect() {
            return m_effect;
        }
        
    }
}