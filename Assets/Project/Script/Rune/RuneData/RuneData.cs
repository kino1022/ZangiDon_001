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
    public class RuneData : SerializedScriptableObject
    {
        [OdinSerialize, LabelText("ルーンの名前")] public string runeName;

        [OdinSerialize, LabelText("ルーン文字のスプライト")] public Sprite runeSprite;

        [SerializeReference, OdinSerialize, LabelText("メイン効果"), Title("一文字目に選択した際の効果")]
        public ICastable Main;

        [SerializeReference, OdinSerialize, LabelText("サブ効果"), Title("二文字目以降に選択した際の効果")]
        public IActivatable Sub;
    }
}