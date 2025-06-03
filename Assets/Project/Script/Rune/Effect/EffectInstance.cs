using System.Collections.Generic;
using Project.Script.Rune.Effect.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Rune.Effect {
    /// <summary>
    /// 対象と効果を一まとまりにした効果のアセット
    /// </summary>
    [CreateAssetMenu(menuName = "Project/Effect/EffectInstance")]
    public class EffectInstance : SerializedScriptableObject {

        [OdinSerialize]
        [SerializeReference]
        protected ITargetSelector m_selector;
        
        [OdinSerialize]
        [SerializeReference]
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