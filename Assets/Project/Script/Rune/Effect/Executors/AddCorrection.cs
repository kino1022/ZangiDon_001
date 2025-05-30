using System;
using Project.Script.Rune.Effect.Interface;
using UnityCommonModule.Correction;
using UnityEngine;

namespace Project.Script.Rune.Effect.Executors {
    /// <summary>
    /// 補正値加算効果のサンプル
    /// </summary>
    [Serializable]
    public class AddCorrectionEffect : IEffectExecutor<CorrectionManager> {
        /// <summary>
        /// 加算する補正値
        /// </summary>
        [SerializeReference] protected ACorrection m_correction;

        public void ExecuteEffect(CorrectionManager target) {
            target.AddCorrection(m_correction);
        }
    }
}