using System;
using System.Collections.Generic;
using Teiwas.Script.Bullet.Context.Intetface;
using Teiwas.Script.Spell.Instance.Interface;
using UnityEngine;

namespace Teiwas.Script.Spell.Instance.Main.Interface {
    public interface IMainSpellInstance : ISpellInstance {

        Action<GameObject> OnCast { get; }

    }
}
