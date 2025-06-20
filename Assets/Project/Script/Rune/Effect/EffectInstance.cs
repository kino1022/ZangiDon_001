using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Rune.Effect.Interface;
using UnityEngine;

namespace Teiwas.Script.Rune.Effect {
    /// <summary>
    /// 対象と効果を一まとまりにした効果のアセット
    /// </summary>
    [Serializable]
    public class EffectInstance {

        [OdinSerialize]
        [SerializeReference,LabelText("対象")]
        protected ITargetSelector m_selector;
        
        [OdinSerialize]
        [SerializeReference,LabelText("発動する効果")]
        protected List<IEffectHolder> m_effects;

        /// <summary>
        /// 効果を発動するメソッド
        /// </summary>
        /// <param name="caster"></param>
        public void Activate(GameObject caster) {
            
            var targets = m_selector.SelectTargets(caster);

            foreach (var target in targets) {
                foreach (var effect in m_effects) {
                    effect.Apply(target);   
                }
            }
        }
    }
}