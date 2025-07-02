using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using Teiwas.Script.Bullet.Movement.Acceleration.Interface;
using Unity.VisualScripting;
using UnityCommonModule.Correction;
using UnityCommonModule.Correction.Interface;
using UnityEngine;

namespace Teiwas.Script.Bullet.Movement.Acceleration {
    /// <summary>
    /// 等加速度運動の際の物体の加速度を示すクラス
    /// </summary>
    [Serializable, LabelText("等加速度")]
    public class ConstantAcceleration : IBulletAccelerationHolder {

        [SerializeField, LabelText("加速度"), ProgressBar(-100.0f,100.0f)]
        protected float m_acce = 0.0f;

        public float Acceleration => m_acce;
        

        public void ApplyCorrect (List<ICorrection> corrections) {
            var executor = new CorrectionManager();

            if (corrections.Count == 0) {
                return;
            }
            
            foreach (var correction in corrections) {
                executor.Add(correction);
            }
            
            m_acce = executor.Execute(m_acce);
        }
    }
}