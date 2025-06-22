using System.Collections.Generic;
using ObservableCollections;
using Teiwas.Script.Rune.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Rune.Manager.Interface;
using UnityEngine;
using Random = System.Random;

namespace Teiwas.Script.Rune.Manager {
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
                InstanceRuneInstance(data);
            }
            
        }
        
        
        public RuneInstance Supply() {
            int index = UnityEngine.Random.Range(0, m_instances.Count);
            
            var rune = m_instances[index];
            
            return rune;
        }

        [Button("インスタンス化")]
        protected virtual void InstanceRuneInstance(RuneData data) {
            m_instances.Add(new RuneInstance(data));
        }
    }
}