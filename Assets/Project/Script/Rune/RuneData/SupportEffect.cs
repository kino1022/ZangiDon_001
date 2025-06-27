using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Bullet.Context.Intetface;
using Teiwas.Script.Rune.Definition;
using Teiwas.Script.Rune.Effect;
using Teiwas.Script.Rune.Interface;
using UnityEngine;

namespace Teiwas.Script.Rune {
    /// <summary>
    /// 二文字目以降に選択した場合の性能を管理するクラス
    /// </summary>
    [Serializable]
    public class SubEffect : ISubEffect {
        
        [OdinSerialize,LabelText("使用回数"),ProgressBar(0,20)]
        public int amount;

        [OdinSerialize, LabelText("")] 
        public IBulletContext Context { get; }
        
        [OdinSerialize,LabelText("効果発動タイミング")]
        public ActivateTiming timing;
        
        [OdinSerialize,SerializeField,LabelText("発動する効果")]
        public List<EffectInstance> effects;

        //---------------------API methods-------------------------------

        public int GetAmount()
        {
            return amount;
        }

        public ActivateTiming GetTiming()
        {
            return timing;
        }

        public void Activate(GameObject caster)
        {
            foreach (var effect in effects)
            {
                effect.Activate(caster);
            }
        }

    }
}