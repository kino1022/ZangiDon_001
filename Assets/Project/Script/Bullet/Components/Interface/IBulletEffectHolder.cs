using System.Collections.Generic;
using Teiwas.Script.Rune.Effect.Interface;
using Teiwas.Script.Rune.Interface;
using UnityEngine;

namespace Project.Script.Bullet.Components.Interface {
    /// <summary>
    /// 弾丸が持つ効果を保持するクラス
    /// </summary>
    public interface IBulletEffectHolder {
        
        public List<IEffect> Effects { get; }
        
        public void ExecuteEffect(GameObject collider);
    }
}