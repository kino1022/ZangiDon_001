using System;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Bullet.Context {
    /// <summary>
    /// 弾丸などのprefabを生成する際に生成側から被生成側に引き渡すクラス
    /// </summary>
    [Serializable]
    public class BulletContext {
        
        protected GameObject m_target;
        
        /// <summary>
        /// 誘導性能に対する補正の情報
        /// </summary>
        protected HomingCorrectionContext m_homing;
    }
}