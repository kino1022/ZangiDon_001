using System;
using Teiwas.Script.Spell.Instance.Interface;
using UnityEngine;

namespace Teiwas.Script.Spell.Manager.EventBus {
    /// <summary>
    /// スペルが選択された際に発行されるEventBus
    /// </summary>
    public readonly struct OnSelectSpellEventBus {
        
        public ISpellInstance Spell { get; }

        public OnSelectSpellEventBus(ISpellInstance spell) {
            if (spell is null) {
                throw new ArgumentNullException();
            }
            Spell = spell;
        }
        
    }
}