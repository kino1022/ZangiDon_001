using System;
using Sirenix.OdinInspector;
using Teiwas.Script.Camera.Angle.Interface;
using UnityEngine;

namespace Teiwas.Script.Camera.Angle.Limiter {
    [Serializable]
    public class NormalAngleLimiter : ICameraAngleLimiter {


        [SerializeField, LabelText("上方向へのアングル限界"), ProgressBar(0.0f, 90.0f)]
        protected float m_up = 0.0f;
        
        [SerializeField, LabelText("下方向へのアングル限界"), ProgressBar(0.0f, 90.0f)]
        protected float m_down = 0.0f;
        
        [SerializeField, LabelText("横方向へのアングル限界"), ProgressBar(0.0f, 90.0f)]
        protected float m_side = 0.0f;


        public Vector3 ApplyLimit(Vector3 value) {
            var result = value;
            
            if (value.y < m_down) result.y = m_down;
            if (value.y > m_up) result.y = m_up;
            if (value.x < 0.0f && Mathf.Abs(value.x) > m_side) result.x = m_side * -1.0f;
            if (value.x > 0.0f && Mathf.Abs(value.x) > m_side) result.x = m_side;
            
            return result;
        }
    }
}