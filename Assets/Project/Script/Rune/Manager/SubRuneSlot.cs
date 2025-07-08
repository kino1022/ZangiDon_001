using System.Collections.Generic;
using Teiwas.Script.Rune.Definition;
using Teiwas.Script.Rune.Effect.Interface;
using Teiwas.Script.Rune.Interface;
using Teiwas.Script.Rune.Manager.Interface;
using UnityEngine;

namespace Teiwas.Script.Rune.Manager {
    public class SubRuneSlot : ARuneManager, ISubRuneSlot{


        public void OnPreCast(GameObject caster) {
            foreach (var rune in m_runes) {
                rune.Value?.Sub.OnPreCast?.Invoke(caster);
            }
        }

        public List<IEffect> GetEffectOnShot() {
            var result = new List<IEffect>();

            foreach (var pair in m_runes) {
                var list = pair.Value.Sub.CastEffects;
                foreach (var e in list) {
                    result.Add(e);
                }
            }
            
            return result;
        }

        public void OnPostCast(GameObject caster) {
            foreach (var rune in m_runes) {
                rune.Value?.Sub.OnPostCast?.Invoke(caster);
            }
        }
    }
}