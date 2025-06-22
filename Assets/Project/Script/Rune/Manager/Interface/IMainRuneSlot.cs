using UnityEngine;

namespace Teiwas.Script.Rune.Manager.Interface {
    
    public interface IMainRuneSlot : IRuneListManager {
        public void OnCasted(GameObject caster);
    }
}