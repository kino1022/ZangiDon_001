using System.Collections.Generic;
using System.Linq;
using Project.Script.Asset.Status.Health;
using Project.Script.UIControl.HealthBar.Interface;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Status;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Project.Script.UIControl.HealthBar {
    public class BarController : SerializedMonoBehaviour , IStatusInstanceHolder {
        
        [OdinSerialize,LabelText("対象のゲームオブジェクト")]
        protected GameObject m_prefab;

        [OdinSerialize, LabelText("最大体力")] protected AStatus<int> m_max;
        
        [OdinSerialize, LabelText("現在体力")] protected AStatus<int> m_current;

        [OdinSerialize, LabelText("バーの可動部分")] protected Image m_bar;
        
        [OdinSerialize, LabelText("割合ごとの色")] protected Dictionary<float,Color> m_colors;

        protected int max = 0;
        
        protected int current = 0;

        protected float ratio = 0.0f;
        
        public AStatus<int> Max => m_max;
        public AStatus<int> Current => m_current;
        

        [Inject]
        public void Construct(GameObject prefab) {
            m_prefab = prefab;
            
            m_max = m_prefab.GetComponent<MaxHealth>();
            m_current = m_prefab.GetComponent<Health>();
        }


        private void Start() {
            
            Observable
                .EveryValueChanged(Max, i => Max.GetValue())
                .Subscribe(i => {
                    max = i;
                    ratio = (float) i / max;
                })
                .AddTo(gameObject);
            
            Observable
                .EveryValueChanged(Max, i => Max.GetValue())
                .Subscribe(i => {
                    current = i;
                    ratio = (float) i / max;
                })
                .AddTo(gameObject);
            
        }

        private void Update() {
            
            
            
            m_bar.fillAmount = ratio;
        }
        
        /// <summary>
        /// 割合のキーの大きさ順のDictionaryを並び替えるメソッド
        /// </summary>
        protected static Dictionary<float,Color> SortColorsDictionary(Dictionary<float,Color> source) {
            return source
                .OrderByDescending(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
        }
        
    }
}