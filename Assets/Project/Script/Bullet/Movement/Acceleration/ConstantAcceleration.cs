using Project.Script.Bullet.Movement.Acceleration.Interface;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityCommonModule.Correction.Interface;
using UnityEngine;

namespace Teiwas.Script.Bullet.Movement.Acceleration {
    /// <summary>
    ///  等加速度運動の際の加速度を表現するクラス
    /// </summary>
    [Serializable]
    public class ConstantAcceleration : IBulletAccelerationHolder {

        [SerializeField, LabelText("加速度"), ProgressBar(-100.0f,100.0f)]
        protected float m_acce = 0.0f;

        public float Acceleration => m_acce;

        public void ApplyCorrect (List<ICorrection> corrections) {
            
        }
    }
}