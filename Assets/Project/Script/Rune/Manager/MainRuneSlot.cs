using Project.Script.Rune.Interface;
using Project.Script.Rune.Manager.Interface;
using UnityEngine;

namespace Project.Script.Rune.Manager {
    public class MainRuneSlot : ARuneManager , IMainRuneSlot {
        
        protected override void OnReceiveRune(IRune rune) {
            
            if (m_isFull) {
                Debug.Log("ルーンが満タンな状態でルーンが補充されました");
                return;
            }
            
            m_runes.Add(rune);
        }

        public void OnCasted(GameObject caster) {
            foreach (var rune in m_runes) {
                rune.Main.OnCast(caster);
            }
        }
    }
}