using System;
using System.Collections.Generic;
using Project.Script.Spell.Instance;
using Teiwas.Script.Bullet.Context.Intetface;
using Teiwas.Script.Spell.Effect.Interface;
using Teiwas.Script.Spell.Instance.Module.Interface;
using Teiwas.Script.Spell.Instance.Sub.Insterface;
using UnityEngine;

namespace Teiwas.Script.Spell.Instance.Sub {
    [Serializable]
    public class SubSpellInstance : ASpellInstance, ISubSpellInstance {

        protected List<ISpellEffect> m_preEffects;

        protected List<ISpellEffect> m_postEffects;

        protected List<ISpellEffect> m_selectEffects;

        protected List<IBulletContextElement> m_contexts;


        public List<IBulletContextElement> Contexts => m_contexts;

        public Action<GameObject> OnPreCast => PreCast;
        
        public Action<GameObject> OnPostCast => PostCast;
        
        public Action<GameObject> OnSelect => Select;

        public SubSpellInstance(List<ISpellEffect> precast, List<ISpellEffect> postcast, List<ISpellEffect> select, List<IBulletContextElement> elements, Sprite sprite, string name, IAmountCounter counter) : base(sprite, name, counter) {
            
        }

        protected void PreCast(GameObject caster) {
            ActivateEffects(caster,m_preEffects);
        }

        protected void PostCast(GameObject caster) {
            ActivateEffects(caster,m_postEffects);
        }

        protected void Select(GameObject caster) {
            ActivateEffects(caster,m_selectEffects);
        }

        protected void ActivateEffects(GameObject caster, List<ISpellEffect> effects) {
            
        }
    }
}