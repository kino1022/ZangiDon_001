using System;
using UnityEngine;

namespace Project.Script.Bullet.Context {
    
    [Serializable]
    public class HomingCorrectionContext {

        protected float m_horizontal = Mathf.Clamp(0.0f, -1.0f, 1.0f);

        protected float m_upward = Mathf.Clamp(0.0f, -1.0f, 1.0f);
        
        protected float m_downward = Mathf.Clamp(0.0f, -1.0f, 1.0f);

        public HomingCorrectionContext(float Horizontal, float Upward, float Downward) {
            m_horizontal = Horizontal;
            m_upward = Upward;
            m_downward = Downward;
        }

        public void AddContext (HomingCorrectionContext context) {
            m_horizontal += context.m_horizontal;
            m_upward += context.m_upward;
            m_horizontal +=  m_downward;
        }
    }
}