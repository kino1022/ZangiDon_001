using System;
using UnityEngine;

namespace Project.Script.UIControl.Utility.TextElement {
    [Serializable]
    public class FontSizeElement {
        
        protected float m_fontSize = Mathf.Min(0.0f,0.0f);
        
        protected Color m_color = Color.white;
        
        public FontSizeElement(float fontSize,Color color) {
            m_fontSize = fontSize;
            m_color = color;
        }

        public void ApplyElement(TMPro.TextMeshPro text) {
            text.fontSize = m_fontSize;
            text.color = m_color;
        }
        
    }
}