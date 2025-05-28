using System;
using System.Collections.Generic;
using Project.Script.Rune.Effect;
using UnityEngine;

namespace Project.Script.Rune.SubEffect {
    /// <summary>
    /// ルーンを二文字目以降に選択した際に発動する効果を記述するクラス
    /// </summary>
    [Serializable]
    [CreateAssetMenu(menuName = "Project/Rune/SubEffect",fileName = "SubEffect")]
    public class SubEffect : ARuneEffect {
        /// <summary>
        /// 発動する効果
        /// </summary>
        public List<AEffect> effects;
    }
}