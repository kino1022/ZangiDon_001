using System;
using UnityEngine;

namespace Project.Script.LockManage {
    public interface ITargetContext : IDisposable {
        
        /// <summary>
        /// ロックしているターゲット
        /// </summary>
        public GameObject Target { get; }
        
        /// <summary>
        /// ターゲットとの距離
        /// </summary>
        public float Distance { get; }
        
        /// <summary>
        /// プレイヤーからターゲットへの方向
        /// </summary>
        public Vector3 Direction { get; }
        
    }
}