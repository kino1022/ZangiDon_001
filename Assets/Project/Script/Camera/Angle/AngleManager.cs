using System;
using Project.Script.Camera.Angle.Interface;
using UnityEngine;

namespace Project.Script.Camera.Angle {
    [Serializable]
    public class AngleManager :  IAngleHolder {
        
        [SerializeField]
        protected Quaternion m_angle = Quaternion.identity;
        
        public Quaternion Angle => m_angle;
        
        
    }
}