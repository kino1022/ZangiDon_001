using System;
using Teiwas.Script.Spell.Instance.Module.Interface;
using UnityEngine;

namespace Teiwas.Script.Spell.Instance.Interface {
    public interface ISpellInstance : IDisposable {

        Sprite Sprite { get; }

        string SpellName { get; }

        IAmountCounter Amount { get; }
    }
}
