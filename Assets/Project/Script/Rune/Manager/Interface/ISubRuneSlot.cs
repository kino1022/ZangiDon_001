using System.Collections.Generic;
using Project.Script.Rune.Interface;
using UnityEngine;

namespace Project.Script.Rune.Manager.Interface {
    public interface ISubRuneSlot {
        
        public void OnPreCast(GameObject rune);

        public List<IActivatable> GetEffectOnShot();
        
        public void OnPostCast(GameObject rune);
        
    }
}