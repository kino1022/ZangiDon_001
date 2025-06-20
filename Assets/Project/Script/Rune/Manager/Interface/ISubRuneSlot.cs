using System.Collections.Generic;
using Teiwas.Script.Rune.Interface;
using UnityEngine;

namespace Teiwas.Script.Rune.Manager.Interface {
    public interface ISubRuneSlot {
        
        public void OnPreCast(GameObject rune);

        public List<ISubEffect> GetEffectOnShot();
        
        public void OnPostCast(GameObject rune);
        
    }
}