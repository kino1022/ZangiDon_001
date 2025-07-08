using System;
using System.Collections.Generic;
using NUnit.Framework;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Bullet.Context.Intetface;
using Teiwas.Script.Rune.Definition;
using Teiwas.Script.Rune.Effect.Interface;
using Teiwas.Script.Rune.Interface;
using Teiwas.Script.Rune.Manage.Modules;
using UnityEngine;

namespace Teiwas.Script.Rune {
    [Serializable]
    public class SubEffectInstance : ISubEffect {
        [OdinSerialize]
        protected RuneCastCountModule m_count;
        [SerializeField]
        protected bool m_isActive = true;
        [OdinSerialize]
        protected List<IEffect> m_castEffects; 
        protected Action<GameObject> m_preCast;
        protected Action<GameObject> m_postCast;
        [OdinSerialize]
        protected IBulletContext m_context;

        public int Amount => m_count.GetAmount();
        public bool IsActive => m_isActive;
        public IBulletContext Context => m_context;
        public List<IEffect> CastEffects => m_castEffects;
        public Action<GameObject> OnPreCast => m_preCast;
        public Action<GameObject> OnPostCast => m_postCast;


        public SubEffectInstance (
            RuneCastCountModule count,
            List<IEffect> effects,
            Action<GameObject> preCast,
            Action<GameObject> postCast,
            IBulletContext context
            ) {
            m_count = count;
            m_castEffects = effects;
            m_preCast = preCast;
            m_postCast = postCast;
            m_context = context;
        }
        
        
    }
}