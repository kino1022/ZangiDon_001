using System.Collections.Generic;
using ObservableCollections;
using Project.Script.Rune.Interface;
using Project.Script.Rune.Manager.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using Random = System.Random;

namespace Project.Script.Rune.Manager {
    public class RuneFactory : SerializedMonoBehaviour , IRuneSupplier {
        
        [SerializeField, OdinSerialize, LabelText("生成するルーンのデータ")]
        protected ObservableList<RuneData> m_datas;
        
        [SerializeField, OdinSerialize, LabelText("インスタンスしたルーン")]
        protected ObservableList<RuneInstance> m_instances;

        private void Awake() {

            if (m_datas.Count == 0) {
                Debug.LogError("ルーンのデータが存在していません");
                return;
            }
            
            foreach (var data in m_datas) {
                m_instances.Add(new RuneInstance(data));
            }
        }
        
        
        public RuneInstance Supply() {
            int index = UnityEngine.Random.Range(0, m_instances.Count);
            
            var rune = m_instances[index];
            
            return rune;
        }
        
        
    }
}