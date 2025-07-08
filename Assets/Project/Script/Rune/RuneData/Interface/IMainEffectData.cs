using UnityEngine;

namespace Teiwas.Script.Rune.Interface {
    public interface IMainEffectData : IRuneEffectData{
        public void OnCast (GameObject caster); 
    }
}