using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Teiwas.Script.Bullet.Movement.FirstSpeed.Interface;
using UnityCommonModule.Correction.Interface;
using UnityEngine;

namespace Teiwas.Script.Bullet.Movement.FirstSpeed {
    [Serializable, LabelText("初速度")]
    public class NormalFirstSpeed : IBulletFirstSpeedHolder {
        
        [SerializeField, LabelText("初速度"), ProgressBar(0.0f, 500.0f)]
        protected float m_speed = 0.0f;

        public float FirstSpeed => m_speed;

        public void ApplyCorrect(List<ICorrection> corrections) {
            
        }
    }
}