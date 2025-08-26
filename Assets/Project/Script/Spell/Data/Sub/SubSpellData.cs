using System;
using System.Collections.Generic;
using Project.Script.Spell.Data;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Bullet.Context.Intetface;
using Teiwas.Script.Spell.Data.Interface;
using Teiwas.Script.Spell.Data.Sub.Interface;
using Teiwas.Script.Spell.Effect.Interface;
using UnityEngine;

namespace Teiwas.Script.Spell.Data.Sub {
    [CreateAssetMenu(menuName = "Project/Spell/Data/Sub")]
    public class SubSpellData : ASpellData , ISubSpellData {
        
        [TitleGroup("性能")]
        [OdinSerialize]
        [LabelText("行使直前の効果")]
        protected List<ISpellEffect> m_preEffects;
        
        [TitleGroup("性能")]
        [OdinSerialize]
        [LabelText("行使直後の効果")]
        protected List<ISpellEffect> m_postEffects;
        
        [TitleGroup("性能")]
        [OdinSerialize]
        [LabelText("選択時の効果")]
        protected List<ISpellEffect> m_selectEffects;
        
        [TitleGroup("性能")]
        [OdinSerialize]
        [LabelText("生成物にかける補正")]
        protected List<IBulletContextElement> m_contexts;
        
        public List<IBulletContextElement> Contexts => m_contexts;

        protected void ActivateEffects(List<ISpellEffect> effects, GameObject caster) {
            
            if (caster is null) {
                throw new ArgumentNullException();
            }
            
            if (effects is null) {
                throw new ArgumentNullException();
            }

            if (effects.Count is 0) {
                return;
            }

            foreach (var effect in effects) {
                if (effect is null) {
                    continue;
                }

                effect.OnActivate(caster);
            }
            
        }

        public void OnPreCast(GameObject caster) => ActivateEffects(m_preEffects, caster);
        
        public void OnPostCast(GameObject caster) => ActivateEffects(m_postEffects, caster);
        
        public void OnSelect(GameObject caster) => ActivateEffects(m_selectEffects, caster);
        
    }
}