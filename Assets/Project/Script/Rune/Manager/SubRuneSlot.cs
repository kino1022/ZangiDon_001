using System.Collections.Generic;
using Teiwas.Script.Rune.Definition;
using Teiwas.Script.Rune.Interface;
using Teiwas.Script.Rune.Manager.Interface;
using UnityEngine;

namespace Teiwas.Script.Rune.Manager {
    public class SubRuneSlot : ARuneManager, ISubRuneSlot{


        public void OnPreCast(GameObject caster) {
            foreach (var rune in m_runes) {
                if (rune.Value.Sub.GetTiming() == ActivateTiming.OnPreCast) {
                    rune.Value.Sub.Activate(caster);
                }
            }
        }

        public List<ISubEffect> GetEffectOnShot() {
            var result = new List<ISubEffect>();
            
            foreach (var rune in m_runes) {
                if (rune.Value.Sub.GetTiming() == ActivateTiming.OnHit) {
                    result.Add(rune.Value.Sub);
                }
            }

            if (result.Count == 0) {
                Debug.Log("ヒットした際に発動する効果がありませんでした");
            }
            
            return result;
        }

        public void OnPostCast(GameObject caster) {
            foreach (var rune in m_runes) {
                if (rune.Value.Sub.GetTiming() == ActivateTiming.OnPostCast) {
                    rune.Value.Sub.Activate(caster);
                }
            }
        }
    }
}