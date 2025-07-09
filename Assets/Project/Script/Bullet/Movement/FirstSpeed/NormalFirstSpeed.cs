using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Bullet.Movement.FirstSpeed.Interface;
using UnityCommonModule.Correction;
using UnityCommonModule.Correction.Interface;
using UnityEngine;

namespace Teiwas.Script.Bullet.Movement.FirstSpeed {
    [Serializable, LabelText("初速度")]
    public class NormalFirstSpeed : IBulletFirstSpeedHolder {

        [SerializeField, LabelText("初速度")]
        protected float m_speed = 0.0f;

        public float FirstSpeed => m_speed;

        [OdinSerialize, LabelText("補正管理クラス")]
        protected ICorrector m_corrector = new CorrectionManager();

        public void ApplyCorrect(List<ICorrection> corrections) {

            Debug.Log("受け取ったICorrectionをもとに速度の補正を行います");

            m_corrector = new CorrectionManager();

            if(corrections is null || corrections.Count is 0) {
                Debug.Log("与えられた補正が存在しませんでした");
                return;
            }

            foreach(var item in corrections) {
                if(item is not null) {
                    m_corrector.Add(item);
                }
                else {
                    Debug.LogError("与えられた補正値クラスがnullでした");
                }
            }

            m_speed = m_corrector.Execute(m_speed);
            Debug.Log("速度の補正が終了しました");
        }
    }
}
