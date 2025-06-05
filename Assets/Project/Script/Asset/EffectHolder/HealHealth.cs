using System;
using Project.Script.Rune.Effect.Interface;
using Project.Script.Status.Asset;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Asset.EffectHolder {
    /// <summary>
    /// 体力を回復する効果のアセット
    /// </summary>
    [Serializable,LabelText("体力回復")]
    public class HealHealth : IEffectHolder {
        
        [OdinSerialize,LabelText("回復量")]
        protected float m_value;
        
        public void Apply(GameObject target) {
            var health = target.GetComponent<Health>();

            if (health == null) {
                Debug.Log($"{target.name}に体力のコンポーネントが存在しませんでした");
                return;
            }
            
            health.Heal(m_value);
        }
    }
}