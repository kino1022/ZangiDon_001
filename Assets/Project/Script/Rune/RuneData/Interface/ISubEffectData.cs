using System.Collections.Generic;
using Teiwas.Script.Bullet.Context.Intetface;
using Teiwas.Script.Rune.Effect.Interface;
using UnityEngine;

namespace Teiwas.Script.Rune.Interface {
    
    public interface ISubEffectData : IRuneEffectData {
        
        public List<IBulletContextElement> Context { get; }
        
        public List<IEffect> CastEffect { get; }
        
        public void OnPreActivate (GameObject caster); 

        public void OnActivate(GameObject caster);
        
        public void OnPostActivate (GameObject caster);
        
    }
}