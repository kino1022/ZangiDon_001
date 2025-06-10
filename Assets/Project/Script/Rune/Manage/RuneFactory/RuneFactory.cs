using System;
using System.Collections.Generic;
using Project.Script.Rune.Manage.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Rune.Manage {
    [Serializable]
    public class RuneFactory : SerializedMonoBehaviour, IRuneSupplier {

        [OdinSerialize,SerializeField] 
        protected List<RuneData> m_datas;
        
        public RuneInstance SupplyRune() {
            return new RuneInstance(GetRandomRuneData());
        }

        protected RuneData GetRandomRuneData() {
            if (m_datas.Count < 0) return null;
            
            var random = new System.Random();
            int index = random.Next(0, m_datas.Count);
            return m_datas[index];
        }
    }
}