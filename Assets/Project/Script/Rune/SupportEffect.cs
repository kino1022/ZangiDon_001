using System;
using System.Collections.Generic;
using Project.Script.Rune.Definition;
using Project.Script.Rune.Effect;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Rune {
    /// <summary>
    /// 二文字目以降に選択した場合の性能を管理するクラス
    /// </summary>
    [Serializable]
    public class SupportEffect {
        
        [OdinSerialize,LabelText("使用回数")]
        protected int amount;
        
        [OdinSerialize,LabelText("効果発動タイミング")]
        protected ActivateTiming timing;
        
        [OdinSerialize,LabelText("発動する効果")]
        protected List<EffectInstance> effects;
        
        //---------------------API methods-------------------------------

        public void Activate(GameObject caster) {
            foreach (var effect in effects) {
                effect.Activate(caster);
            }
        }

        #region Amount

        public int GetAmount() {
            return amount;
        }

        #endregion

        #region ActivateTiming

        public ActivateTiming GetTiming() {
            return timing;
        }

        #endregion

    }
}