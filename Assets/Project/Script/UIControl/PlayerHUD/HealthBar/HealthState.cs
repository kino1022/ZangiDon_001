using Unity.Mathematics;
using UnityEngine;

namespace Teiwas.Script.UIControl.PlayerHUD.HealthBar {
    /// <summary>
    /// PresenterからViewに対してHealthの状態を通知するための構造体
    /// </summary>
    public struct HeatlhState {
        /// <summary>
        /// 現在の体力の割合
        /// </summary>
        public float Ratio;

        public float Max;

        public float Current;

        public HeatlhState(float ratio, float max, float current) {
            Ratio = ratio;

            Max = max;

            Current = current;
        }
    }
}
