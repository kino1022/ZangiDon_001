using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.StatusEffect {
    [Serializable]
    public abstract class AStatusEffect {
        
        public abstract void Activate (GameObject target); 
        
        public abstract void Deactivate (GameObject target);
    }
}