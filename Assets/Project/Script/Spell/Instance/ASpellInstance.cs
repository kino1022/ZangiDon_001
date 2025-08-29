using System;
using Sirenix.Serialization;
using Teiwas.Script.Spell.Data.Interface;
using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Instance.Main.Interface;
using Teiwas.Script.Spell.Instance.Module;
using Teiwas.Script.Spell.Instance.Module.Interface;
using UnityEngine;

namespace Project.Script.Spell.Instance {
    [Serializable]
    public abstract class ASpellInstance : ISpellInstance {

        [OdinSerialize]
        protected IAmountCounter m_amount;

        [SerializeField]
        protected Sprite m_sprite;
        
        [SerializeField]
        protected string m_spellName;
        
        public IAmountCounter Amount => m_amount;
        
        public Sprite Sprite => m_sprite;
        
        public string SpellName => m_spellName;

        protected ASpellInstance(Sprite sprite, string spellName, IAmountCounter amount) {
            m_sprite = sprite ?? throw new ArgumentNullException(nameof(sprite));
            
            m_spellName = spellName ?? throw new ArgumentNullException(nameof(spellName));
            
            m_amount = amount ?? throw new ArgumentNullException(nameof(amount));
        }

        public virtual void Dispose() {
            
        }
    }
}