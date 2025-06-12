using System.Collections.Generic;
using System.Linq;
using Project.Script.Asset.Status.Health;
using Project.Script.UIControl.HealthBar.Interface;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Unity.VisualScripting;
using UnityCommonModule.Status;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Project.Script.UIControl.HealthBar {
    public class BarController : SerializedMonoBehaviour, IStatusInstanceHolder
    {

        [OdinSerialize, LabelText("対象のゲームオブジェクト")]
        protected GameObject m_prefab;

        [OdinSerialize, LabelText("最大体力")] protected AStatus<int> m_max;

        [OdinSerialize, LabelText("現在体力")] protected AStatus<int> m_current;

        [OdinSerialize, LabelText("バーの可動部分")] protected Image m_bar;

        [OdinSerialize, LabelText("割合ごとの色")] protected List<(float, Color)> m_colors;

        protected int max = 0;

        protected int current = 0;

        protected float ratio = 0.0f;

        public AStatus<int> Max => m_max;
        public AStatus<int> Current => m_current;


        [Inject]
        public void Construct(GameObject prefab)
        {
            m_prefab = prefab;

            m_max = m_prefab.GetComponent<MaxHealth>();
            m_current = m_prefab.GetComponent<Health>();
        }


        private void Start()
        {
            m_colors = SortListFromValue(m_colors);

            Observable
                .EveryValueChanged(Max, i => Max.GetValue())
                .Subscribe(i =>
                {
                    max = i;
                    ratio = (float)i / max;
                })
                .AddTo(gameObject);

            Observable
                .EveryValueChanged(Max, i => Max.GetValue())
                .Subscribe(i =>
                {
                    current = i;
                    ratio = (float)i / max;
                })
                .AddTo(gameObject);

        }

        private void Update()
        {
            m_bar.color = CalculateBarColor();

            m_bar.fillAmount = ratio;
        }

        protected Color CalculateBarColor()
        {
            for (int i = 0; i < m_colors.Count; i++) {
                if (m_colors[i].Item1 <= ratio && m_colors[i + 1].Item1 >= ratio)
                {
                    return m_colors[i].Item2;
                }
            }
            return m_colors[^m_colors.Count].Item2;
        }

        protected List<(float,Color)> SortListFromValue(List<(float,Color)> source)
        {
            return source.OrderByDescending(item => item.Item1)
            .ToList();
        }

    }
}