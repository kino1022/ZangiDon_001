using System;
using System.Collections.Generic;
using Teiwas.Script.Rune.Effect;

namespace Teiwas.Script.Bullet {
    /// <summary>
    /// 弾丸のprefabを生成する際にprefabに対して渡す情報
    /// </summary>
    [Serializable]
    public class BulletContext {
        
        /// <summary>
        /// 効果値の補正割合
        /// </summary>
        public float correction = 0.0f;
        
        /// <summary>
        /// 縦方向の誘導の補正割合
        /// </summary>
        public float verticalHoming = 0.0f;
        
        /// <summary>
        /// 横方向への誘導の補正割合
        /// </summary>
        public float horizontalHoming = 0.0f;
        
        /// <summary>
        /// 弾速への補正割合
        /// </summary>
        public float bulletSpeed = 0.0f;
        
        /// <summary>
        /// ヒット時に発動する効果
        /// </summary>
        public List<EffectInstance> onHitEffects = new List<EffectInstance>();
        
    }
}