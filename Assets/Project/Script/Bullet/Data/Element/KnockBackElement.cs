using System;
using System.Numerics;
using Sirenix.OdinInspector;

namespace Teiwas.Script.Bullet.Data.Element {
    [Serializable]
    public class KnockBackElement {
        
        [LabelText("ノックバックを有効化するか")]
        public bool Enable = true;
        
        [LabelText("吹っ飛ぶ方向")]
        public Vector3 Direction = new Vector3(0,0,0);

        [LabelText("吹っ飛ぶ距離"), ProgressBar(0.0f, 100.0f)]
        public float Force = 0.0f;
        
    }
}