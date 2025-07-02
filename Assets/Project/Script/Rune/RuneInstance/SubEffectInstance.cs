using System;
using System.Collections.Generic;
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

        protected RuneCastCountModule m_count;
        protected bool m_isActive = true;
        protected List<IEffect> m_castEffects; 
        protected Action<GameObject> m_preCast;
        protected Action<GameObject> m_onCast;
        protected Action<GameObject> m_postCast;
        protected IBulletContext m_context;

        public int Amount => m_count.GetAmount();
        public bool IsActive => m_isActive;
        public IBulletContext Context => m_context;
        public List<IEffect> CastEffects => m_castEffects;
        public Action<GameObject> OnPreCast => m_preCast;
        public Action<GameObject> OnCast => m_onCast;
        public Action<GameObject> OnPostCast => m_postCast;
        
        
    }
}