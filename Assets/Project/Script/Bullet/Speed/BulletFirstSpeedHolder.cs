using System;
using Project.Script.Bullet.Speed.Interface;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Script.Bullet.Speed {
    /// <summary>
    /// 
    /// </summary>
    [Serializable, LabelText("初速")]
    public class BulletFirstSpeedHolder : IBulletFirstSpeedHolder {
        
        [SerializeField, LabelText("初速"), ProgressBar(0,500.0f)]
        protected float m_speed;
        
        public float Speed => m_speed;
        
    }
}