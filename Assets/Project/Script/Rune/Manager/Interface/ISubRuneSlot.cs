using System.Collections.Generic;
using Teiwas.Script.Rune.Effect.Interface;
using Teiwas.Script.Rune.Interface;
using UnityEngine;

namespace Teiwas.Script.Rune.Manager.Interface {
    public interface ISubRuneSlot : IRuneListManager{
        
        public void OnPreCast(GameObject rune);

        public List<IEffect> GetEffectOnShot();
        
        public void OnPostCast(GameObject rune);
        
    }
}