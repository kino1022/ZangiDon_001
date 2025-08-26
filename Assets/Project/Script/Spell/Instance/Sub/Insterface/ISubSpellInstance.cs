using System;
using System.Collections.Generic;
using Teiwas.Script.Bullet.Context.Intetface;
using Teiwas.Script.Spell.Instance.Interface;
using UnityEngine;

namespace Teiwas.Script.Spell.Instance.Sub.Insterface {
    public interface ISubSpellInstance : ISpellInstance {

        List<IBulletContextElement> Contexts { get; }

        Action<GameObject> OnSelect { get; }

        Action<GameObject> OnPreCast { get; }

        Action<GameObject> OnPostCast { get; }
    }
}
