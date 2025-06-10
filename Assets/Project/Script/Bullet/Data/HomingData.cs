using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Project.Script.Bullet.Data {
    [Serializable]
    public class HomingData {
        
        [OdinSerialize, LabelText("水平方向への誘導強度"), ProgressBar(0.0f, 100.0f)]
        public float horizontal;

        [OdinSerialize, LabelText("上方向への誘導強度"), ProgressBar(0.0f, 100.0f)]
        public float upward;
        
        [OdinSerialize,LabelText("下方向への誘導強度"),ProgressBar(0.0f, 100.0f)]
        public float downward;
    }
}