using System.Collections.Generic;
using ObservableCollections;
using Teiwas.Script.Rune.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Rune.Factory;
using Teiwas.Script.Rune.Manager.Interface;
using UnityEngine;

namespace Teiwas.Script.Rune.Manager {
    public class RuneFactory : SerializedMonoBehaviour , IRuneSupplier {

        [SerializeField, OdinSerialize, LabelText("生成するルーンのデータ")]
        protected ObservableList<RuneData> m_datas;


        [OdinSerialize, LabelText("ゲーム中で使用するデータのインスタンス")]
        protected ObservableList<RuneData> m_runtimeData = new ObservableList<RuneData>();

        private void Awake() {

            if(m_datas.Count == 0) {
                Debug.LogError("ルーンのデータが存在していません");
                return;
            }

            foreach(var data in m_datas) {
                m_runtimeData.Add(Instantiate(data));
            }

        }


        public IRune Supply() {
            var index = UnityEngine.Random.Range(0, m_runtimeData.Count);
            return InstanceRuneInstance(m_runtimeData[index]);
        }

        [Button("インスタンス化")]
        protected virtual IRune InstanceRuneInstance(RuneData data) {
            return new RuneInstanceFactory(data).Create();
        }
    }
}
