using System;
using Project.Script.Rune.Interface;
using UnityEngine;

namespace Project.Script.Rune.Magic {
    public class AMagic : IMagicExecutor {
        [Range(0,100)]
        protected int amount;
        
        public void ExecuteMagic() {
            
        }
    }
}