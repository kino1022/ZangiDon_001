using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Asset.Status.Health;
using Teiwas.Script.Rune.Effect.Interface;
using UnityEngine;

namespace Teiwas.Script.Asset.EffectHolder {
    /// <summary>
    /// 体力を回復する効果のアセット
    /// </summary>
    [Serializable,LabelText("体力回復")]
    public class HealHealth : IEffectHolder {
        
        [OdinSerialize,LabelText("回復量"),ProgressBar(0,500)]
        protected int m_value;
        
        public void Apply(GameObject target) {
            var health = target.GetComponent<Health>();

            if (health == null) {
                Debug.Log($"{target.name}に体力のコンポーネントが存在しませんでした");
                return;
            }

            health.Heal.Heal(m_value);
        }
    }
}