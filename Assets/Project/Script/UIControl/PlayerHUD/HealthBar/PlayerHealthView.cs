using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.UIControl.PlayerHUD.HealthBar.Interface;
using UnityEngine;

using System.Collections.Generic;

namespace Teiwas.Script.UIControl.PlayerHUD.HealthBar {
    public class PlayerHealthView : SerializedMonoBehaviour, IPlayerHealthBarView {

        [SerializeField, LabelText("最大耐久値のテキスト")]
        protected TMPro.TMP_Text m_maxText;


        [SerializeField, LabelText("現在耐久値のテキスト")]
        protected TMPro.TMP_Text m_currentText;

        [OdinSerialize, LabelText("割合に対応した体力ゲージの色")]
        protected List<ColorWithRatio> m_colors = new List<ColorWithRatio>();



        public void OnStateChange(HeatlhState state) {

        }

        protected void UpdateText() {
            
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
