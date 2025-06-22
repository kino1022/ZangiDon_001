using UnityEngine;

namespace Teiwas.Script.Rune.Interface {
    public interface IRune {
        
        public Sprite RuneSprite { get; }

        public bool GetIsActive();
        
        /// <summary>
        /// メインの効果
        /// </summary>
        public IMainEffect Main { get; }
        
        /// <summary>
        /// サブの効果
        /// </summary>
        public ISubEffect Sub { get; }
        
        
    }
}