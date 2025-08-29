using System.Collections.Generic;
using Teiwas.Script.Bullet.Context.Intetface;
using Teiwas.Script.Spell.Data.Interface;
using Teiwas.Script.Spell.Effect.Interface;
using UnityEngine;

namespace Teiwas.Script.Spell.Data.Sub.Interface {
    public interface ISubSpellData : ISpellData {

        List<IBulletContextElement> Contexts { get; }

        List<ISpellEffect> PreCast { get; }
        
        List<ISpellEffect> PostCast { get; }
        
        List<ISpellEffect> Select { get; }

    }
}
