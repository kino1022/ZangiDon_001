using System;
using System.Collections.Generic;
using Project.Script.Rune.Effect;
using UnityEngine;

namespace Project.Script.Rune.MainEffect {
    /// <summary>
    /// ルーンを一文字目に選択した際の効果を記述するクラス
    /// </summary>
    [Serializable]
    [CreateAssetMenu(fileName = "MainEffect", menuName = "Project/Rune/MainEffect")]
    public abstract class AMainEffect : ARuneEffect {
        
        /// <summary>
        /// 使用時に発動する効果
        /// </summary>
        public List<AEffect> effects;
        
        /// <summary>
        /// 魔術が使用されたタイミングで呼ばれる仮想メソッド
        /// </summary>
        protected virtual void OnCast() {
            
        }
    }
}