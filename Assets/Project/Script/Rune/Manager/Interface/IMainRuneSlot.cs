using UnityEngine;

namespace Project.Script.Rune.Manager.Interface {
    
    public interface IMainRuneSlot : IRuneListManager {
        public void OnCasted(GameObject caster);
    }
}