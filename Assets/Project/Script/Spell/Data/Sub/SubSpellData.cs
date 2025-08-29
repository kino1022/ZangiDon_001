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

        public List<ISpellEffect> PreCast => m_preEffects;

        public List<ISpellEffect> PostCast => m_postEffects;
        
        public List<ISpellEffect> Select => m_selectEffects;

        
    }
}