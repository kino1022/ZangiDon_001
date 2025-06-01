using System;
using System.Collections.Generic;
using System.Linq;
using Project.Script.Interface;
using Project.Script.Rune.Effect;
using Project.Script.Rune.Effect.Definition;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Project.Script.Rune {
    /// <summary>
    /// 二文字目以降に選択した場合の情報を管理するクラス
    /// </summary>
    [Serializable]
    public class SupportEffect {
        
        /// <summary>
        /// 使用回数
        /// </summary>
        [InspectorName("使用回数")]
        [OdinSerialize]
        protected int m_amount;
        
        [InspectorName("発動する効果")]
        [OdinSerialize]
        protected List<AEffectBase> m_effects;

        public SupportEffect() {
            
        }
        
        //-------------API　Methods----------------------------

        public void SetAmount(int amount) {
            m_amount = amount;
        }

        public void IncreaseAmount(int amount) {
            m_amount += amount;
        }

        public void DecreaseAmount(int amount) {
            m_amount -= amount;
        }

        public void RemoveEffect(AEffectBase effect) {
            if (effect == null) {
                Debug.Log("選択された効果は存在しませんでした");
                return;
            }
            
            m_effects.Remove(effect);
        }

        public void AddEffect(AEffectBase effect) {
            m_effects.Add(effect);
        }

        public void ExecuteFromTiming(ActivateTiming timing) {
            var effects = SortEffectsFromTiming(timing);

            if (effects == null) {
                Debug.Log("指定されたタイミングで発動する効果は存在しませんでした");
                return;
            }
            ExecuteEffectFromList(effects);
            DecreaseAmount(1);
        }
        
        //-----------------setup methods-------------------------------
        
        
        
        //-----------------Logical methods-----------------------------
        
        /// <summary>
        /// 指定したタイミングで発動する効果を全て取得する
        /// </summary>
        /// <param name="timing"></param>
        /// <returns></returns>
        protected List<AEffectBase> SortEffectsFromTiming(ActivateTiming timing) {
            return m_effects.FindAll(x => x.Timing == timing);
        }
        
        /// <summary>
        /// 引数として渡された効果を全て実行する
        /// </summary>
        /// <param name="effects"></param>
        protected void ExecuteEffectFromList(List<AEffectBase> effects) {
            foreach (var effect in effects) {
                effect.OnActivate();
            }
        }
    }
}