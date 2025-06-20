using Teiwas.Script.Rune.Interface;
using Teiwas.Script.Rune.Manager.Interface;
using UnityEngine;

namespace Teiwas.Script.Rune.Manager {
    public class MainRuneSlot : ARuneManager , IMainRuneSlot {

        public void OnCasted(GameObject caster) {
            foreach (var rune in m_runes) {
                rune.Main.OnCast(caster);
            }
        }
    }
}