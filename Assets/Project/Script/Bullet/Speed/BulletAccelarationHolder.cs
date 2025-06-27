using System;
using Project.Script.Bullet.Speed.Interface;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Script.Bullet.Speed {
    [Serializable, LabelText("加速度")]
    public class BulletAccelerationHolder : IBulletAccelerationHolder {

        [SerializeField, LabelText("加速度"), ProgressBar(-500.0f, 500.0f)]
        protected float m_acceleration = 0.0f;
        
        public float Acceleration => m_acceleration;
        
    }
}