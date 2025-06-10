using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Project.Script.Bullet.Data {
    [Serializable]
    public class SpeedData {
        
        [OdinSerialize,LabelText("初速"),ProgressBar(0.0f,500.0f)] 
        public float speed;
        
        [OdinSerialize,LabelText("加速度"),ProgressBar(0.0f,500.0f)]
        public float acceleration;
        
    }
}