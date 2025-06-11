using System;
using System.Collections.Generic;
using Project.Script.Rune.Manager.Factory;
using Project.Script.Rune.Manager.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Project.Script.Rune {
    public class RuneInstanceFactory : SerializedMonoBehaviour , IRuneSupplier {
        
        [OdinSerialize] 
        protected List<RuneData> m_datas;

        public RuneInstance SupplyRune() {
            var index = UnityEngine.Random.Range(0, m_datas.Count);
            return new RuneInstance(m_datas[index]);
        }
    }
}