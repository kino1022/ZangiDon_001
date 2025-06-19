using Project.Script.Rune.Interface;
using Project.Script.Rune.Manager.Interface;
using UnityEngine;

namespace Project.Script.Rune.Manager {
    public class MainRuneSlot : ARuneManager , IMainRuneSlot {

        public void OnCasted(GameObject caster) {
            foreach (var rune in m_runes) {
                rune.Main.OnCast(caster);
            }
        }
    }
}