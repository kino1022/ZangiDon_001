using System;
using Project.Script.Bullet.Homing.Interface;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Script.Bullet.Homing {
    /// <summary>
    /// 誘導の強さを表現するクラス
    /// </summary>
    [Serializable]
    public class HomingForce : IHomingForce {

        [SerializeField, ProgressBar(0.0f, 100.0f), LabelText("上方への誘導の強さ")]
        protected float m_upper = Mathf.Min(0.0f, 0.0f);

        public float Upper => m_upper;

        [SerializeField, ProgressBar(0.0f, 100.0f),LabelText("下方への誘導の強さ")]
        protected float m_lower = Mathf.Min(0.0f, 0.0f);
        
        public float Lower => m_lower;
        
        [SerializeField, ProgressBar(0.0f, 100.0f),LabelText("右側への誘導の強さ")]
        protected float m_right = Mathf.Min(0.0f, 0.0f);
        
        public float Right => m_right;
        
        
        [SerializeField, ProgressBar(0.0f, 100.0f),LabelText("左側への誘導の強さ")]
        protected float m_left = Mathf.Min(0.0f, 0.0f);
        
        public float Left => m_left;


        public void Add(IHomingForce force) {
            m_upper += force.Upper;
            m_lower += force.Lower;
            m_right += force.Right;
            m_left = force.Left;
        }
    }
}