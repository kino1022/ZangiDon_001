using System.Collections.Generic;
using Teiwas.Script.Bullet.Context.Intetface;
using Teiwas.Script.Spell.Data.Interface;
using UnityEngine;

namespace Teiwas.Script.Spell.Data.Sub.Interface {
    public interface ISubSpellData : ISpellData {

        List<IBulletContext> Contexts { get; }

        void OnSelect (GameObject caster);

        void OnPreCast (GameObject caster);

        void OnPostCast (GameObject caster);
    }
}
