using System.Collections.Generic;
using Project.Script.Rune.Definition;
using Project.Script.Rune.Interface;
using Project.Script.Rune.Manager;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Project.Script.Rune {
    public class CastExecutorMonoBehaviour : SerializedMonoBehaviour {
        
        [OdinSerialize]
        protected IRuneListHolder m_mainSlot;
        
        [OdinSerialize]
        protected IRuneListHolder m_subSlot;

        private void Start() {
            
            var managerBehaviour = this.GetComponent<RuneManagerMonoBehaviour>();

            m_mainSlot = managerBehaviour.Main;
            m_subSlot = managerBehaviour.Sub;
            
        }
        
        [Button("魔術実行")]
        public void OnCast() {
            
            var onPreCast = GetSubEffectFromTiming(ActivateTiming.OnPreCast);
            var onPostCast = GetSubEffectFromTiming(ActivateTiming.OnPostCast);

            foreach (var effect in onPreCast) {
                effect.Support.OnActivate(this.gameObject);
            }
            
            m_mainSlot.GetRune(0).Cast.OnCast(this.gameObject);

            foreach (var effect in onPostCast) {
                effect.Support.OnActivate(this.gameObject);
            }
            
        }
        
        public List<RuneInstance> GetSubEffectFromTiming(ActivateTiming timing) {
            var list = m_subSlot.GetRuneList();
            
            var result = new List<RuneInstance>();

            foreach (var rune in list) {
                if (rune.Support.GetTiming() == timing) {
                    result.Add(rune);
                }
            }
            
            return result;
        }
    }
}