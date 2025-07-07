using System;
using Sirenix.OdinInspector;
using Teiwas.Script.Camera.Position.Interface;
using UnityEngine;

namespace Teiwas.Script.Camera.Position {
    
    [Serializable]
    public class NormalOffsetController : ICameraOffSetHolder {

        [SerializeField, LabelText("追従対象からの距離"), ProgressBar(0.0f,20.0f)]
        public float m_distance = 0.0f;
        
        [SerializeField, LabelText("追従対象からの高さ"), ProgressBar(0.0f,20.0f)]
        protected float m_height = 0.0f;

        public float Distance {
            get => m_distance;
            set => m_distance = value;
        }

        public float Height {
            get => m_height;
            set => m_height = value;
        }
    }
}