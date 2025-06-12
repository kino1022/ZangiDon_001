using Project.Script.Rune.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Script.Rune {
    /// <summary>
    /// ルーンの発動魔術と効果を管理するクラス
    /// </summary>
    [CreateAssetMenu(menuName = "Project/Rune/Rune")]
    public class RuneData : SerializedScriptableObject {

        [SerializeField] public string RuneName;

        [SerializeField] public Sprite RuneSprite;

        /// <summary>
        /// 一文字目に使用した際の発動する魔術を管理するクラス
        /// </summary>
        [OdinSerialize, SerializeReference, LabelText("発動魔術"), Title("一文字目の効果")]
        public AMainEffect m_cast;
        
        /// <summary>
        /// 二文字目以降に選択された際の付随する効果を管理するクラス
        /// </summary>
        [OdinSerialize, SerializeField,LabelText("補助効果"),Title("二文字目以降の効果")]
        public SupportEffect m_effect;
        
    }
}