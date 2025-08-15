using UnityEngine;

namespace Teiwas.Script.Spell.Data.Interface {
    public interface ISpellData {

        Sprite Sprite { get; }

        string SpellName { get; }

        int MaxAmount { get; }
    }
}
