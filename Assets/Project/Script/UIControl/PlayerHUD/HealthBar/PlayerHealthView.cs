using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.UIControl.PlayerHUD.HealthBar.Interface;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Teiwas.Script.UIControl.PlayerHUD.HealthBar {
    public class PlayerHealthView : SerializedMonoBehaviour, IPlayerHealthBarView {

        [SerializeField, LabelText("体力のテキスト表記")]
        protected TMPro.TMP_Text m_text;

        [OdinSerialize, LabelText("割合に対応した体力ゲージの色")]
        protected List<ColorWithRatio> m_colors = new List<ColorWithRatio>();

        [SerializeField, LabelText("ラベル画像")]
        protected Image m_bar;

        public void OnStateChange(HeatlhState state) {
            UpdateText(state);
            UpdateBar(state);
        }

        protected void UpdateText(HeatlhState state) {
            m_text.text = state.Current + " / " + state.Max;
        }

        protected void UpdateBar(HeatlhState state) {

            m_bar.fillAmount = state.Ratio;

            m_bar.color = Color.Lerp(
                m_bar.color,
                GetColorFromRatio(state.Ratio),
                state.Ratio
                );
        }

        //HPの割合からHPバーの取るべき色を取得する
        protected Color GetColorFromRatio(float ratio) {

            foreach(var item in m_colors) {
                if(item.MaxRatio <= ratio && item.MinRatio >= ratio) {
                    return item.BarColor;
                }
            }

            return Color.green;
        }

    }

    /// <summary>
    /// 割合ごとの体力ゲージの色を示すクラス
    /// </summary>
    [Serializable]
    public struct ColorWithRatio {
        public float MaxRatio;
        public float MinRatio;
        public Color BarColor;
    }
}
