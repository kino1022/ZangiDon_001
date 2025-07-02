using System;
using System.Collections.Generic;
using Teiwas.Script.Bullet.Context.Intetface;
using Teiwas.Script.Rune.Definition;
using Teiwas.Script.Rune.Effect.Interface;
using UnityEngine;

namespace Teiwas.Script.Rune.Interface {
    /// <summary>
    /// 効果を発動できるクラスに対して約束するインターフェース
    /// </summary>
    public interface ISubEffect : IRuneEffect {
        
        public IBulletContext Context { get; }
        
        public List<IEffect> CastEffects { get; }
    
        public Action<GameObject> OnPreCast { get; }
        
        public Action<GameObject> OnPostCast { get; }
        
    }
}