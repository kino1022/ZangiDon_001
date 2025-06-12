using System.Collections.Generic;
using System.Diagnostics;
using Project.Script.Rune.Definition;
using Project.Script.Rune.Interface;
using Project.Script.Rune.Manager;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Rune {
    public class CastExecutorMonoBehaviour : SerializedMonoBehaviour
    {

        [OdinSerialize]
        protected IRuneListHolder m_mainSlot;

        [OdinSerialize]
        protected IRuneListHolder m_subSlot;

        private void Start()
        {

            var managerBehaviour = this.GetComponent<RuneManagerMonoBehaviour>();

            m_mainSlot = managerBehaviour.Main;
            m_subSlot = managerBehaviour.Sub;

        }

        [Button("魔術実行")]
        public void OnCast()
        {
            SubEffectExecute(GetSubEffectFromTiming(ActivateTiming.OnPreCast));
            m_mainSlot.GetRune(0).Main.OnCast(this.gameObject);
            SubEffectExecute(GetSubEffectFromTiming(ActivateTiming.OnPostCast));
        }

        public List<RuneInstance> GetSubEffectFromTiming(ActivateTiming timing)
        {
            var list = m_subSlot.GetRuneList();

            var result = new List<RuneInstance>();

            foreach (var rune in list)
            {
                if (rune.Sub.GetTiming() == timing)
                {
                    result.Add(rune);
                }
                
            }

            return result;
        }

        protected virtual void SubEffectExecute(List<RuneInstance> runes)
        {

            if (runes == null)
            {
                UnityEngine.Debug.LogWarning("実行できる副次効果がありません");
                return;
            }

            foreach (var rune in runes)
            {
                rune.Sub.Activate(this.gameObject);
            }
            
        }
    }
}