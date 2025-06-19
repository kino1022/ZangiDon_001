using System.Collections.Generic;
using Project.Script.Rune.Definition;
using Project.Script.Rune.Interface;
using Project.Script.Rune.Manager.Interface;
using UnityEngine;

namespace Project.Script.Rune.Manager {
    public class SubRuneSlot : ARuneManager, ISubRuneSlot{


        public void OnPreCast(GameObject caster) {
            foreach (var rune in m_runes) {
                if (rune.Sub.GetTiming() == ActivateTiming.OnPreCast) {
                    rune.Sub.Activate(caster);
                }
            }
        }

        public List<IActivatable> GetEffectOnShot() {
            var result = new List<IActivatable>();
            
            foreach (var rune in m_runes) {
                if (rune.Sub.GetTiming() == ActivateTiming.OnHit) {
                    result.Add(rune.Sub);
                }
            }

            if (result.Count == 0) {
                Debug.Log("ヒットした際に発動する効果がありませんでした");
            }
            
            return result;
        }

        public void OnPostCast(GameObject caster) {
            foreach (var rune in m_runes) {
                if (rune.Sub.GetTiming() == ActivateTiming.OnPostCast) {
                    rune.Sub.Activate(caster);
                }
            }
        }
    }
}