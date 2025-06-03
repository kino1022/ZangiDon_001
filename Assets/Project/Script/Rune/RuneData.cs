using Project.Script.Rune.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEditor;
using UnityEngine;

namespace Project.Script.Rune {
    /// <summary>
    /// ルーンの発動魔術と効果を管理するクラス
    /// </summary>
    [CreateAssetMenu(menuName = "Project/Rune/Rune")]
    public class RuneData : SerializedScriptableObject {
        
        /// <summary>
        /// 一文字目に使用した際の発動する魔術を管理するクラス
        /// </summary>
        [OdinSerialize, SerializeField] protected ICastable m_cast;
        
        /// <summary>
        /// 二文字目以降に選択された際の付随する効果を管理するクラス
        /// </summary>
        [OdinSerialize,SerializeField] protected SupportEffect m_effect;

        public SupportEffect GetSupportEffect() {
            return m_effect;
        }
        
        public virtual void OnSelected (GameObject caster) {}
        
        public virtual void OnCast (GameObject caster) {}
        
    }
}