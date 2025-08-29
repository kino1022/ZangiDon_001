using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Spell.Data.Interface;
using Teiwas.Script.Spell.Factory.Pattern.Interface;

namespace Teiwas.Script.Spell.Factory.Pattern {
    [Serializable]
    public abstract class ASpellLotteryPattern<Data> : ISpellLotteryPattern<Data>
        where Data : ISpellData 
    {

        [OdinSerialize, LabelText("生成スペルと確率の大きさ")]
        protected Dictionary<int, Data> m_datas = new();

        [OdinSerialize, LabelText("ランタイムデータ"), ReadOnly]
        protected Dictionary<int, Data> m_runtimeData = new();

        public void Start() {
            m_runtimeData = CreateRuntimeData();
        }

        protected Dictionary<int, Data> CreateRuntimeData() {
            if (m_datas.Count is 0 || m_datas is null) {
                throw new NullReferenceException();
            } 
            return new(m_datas);
        }

        public Data GetCreateData() {
            int totalWeight = 0;

            foreach (var data in m_runtimeData) {
                totalWeight += data.Key;
            }
            
            var lottery = UnityEngine.Random.Range(0, totalWeight);

            int progress = 0;

            foreach (var data in m_runtimeData) {
                progress += data.Key;
                
                if (progress <= lottery) {
                    return data.Value;
                }
            }
            
            throw new NullReferenceException();
        }
    }
}