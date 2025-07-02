using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Bullet.Context;
using Teiwas.Script.Bullet.Context.Intetface;
using Teiwas.Script.Rune.Definition;
using Teiwas.Script.Rune.Effect;
using Teiwas.Script.Rune.Effect.Interface;
using Teiwas.Script.Rune.Interface;
using Unity.VisualScripting;
using UnityEngine;

namespace Teiwas.Script.Rune {
    /// <summary>
    /// 二文字目以降に選択した場合の性能を管理するクラス
    /// </summary>
    [Serializable]
    public class SubEffectData : ISubEffectData , IInitializable {

        [OdinSerialize, LabelText("使用回数"), ProgressBar(0, 20)]
        protected int amount = Mathf.Min(0, 0);

        [OdinSerialize, LabelText("生成物への補正")]
        protected List<IBulletContextElement> m_context = new();
        
        [OdinSerialize,LabelText("ヒット時に発動する効果")]
        protected List<IEffect> OnHitEffect = new();

        [OdinSerialize,LabelText("魔法使用直前に発動する効果")] 
        protected List<IEffect> m_preCastEffects = new();

        [OdinSerialize,LabelText("魔法使用直後に発動する効果")]
        protected List<IEffect> m_postCastEffects = new();

        public int Amount => amount;

        public List<IEffect> CastEffect => OnHitEffect;

        public List<IBulletContextElement> Context => m_context;

        public void OnPreCast (GameObject caster) {

            if (caster == null) {
                Debug.LogError($"{this.GetType()}の処理の引数にゲームオブジェクトが与えられませんでした");
                return;
            }

            foreach (var effect in m_preCastEffects) {
                effect.Activate(caster);
            }
        }

        public void OnPostCast (GameObject caster) {

			if (caster == null) {
				Debug.LogError($"{this.GetType()}の処理の引数にゲームオブジェクトが与えられませんでした");
				return;
			}

            foreach(var effect in m_postCastEffects) {
                effect.Activate(caster);
            }
		}

        public void Initialize () {

        }
    }
}