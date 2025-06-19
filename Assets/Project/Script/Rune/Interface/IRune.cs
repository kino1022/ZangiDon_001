using UnityEngine;

namespace Project.Script.Rune.Interface {
    public interface IRune {
        
        public Sprite RuneSprite { get; }

        public bool GetIsActive();
        
        /// <summary>
        /// メインの効果
        /// </summary>
        public ICastable Main { get; }
        
        /// <summary>
        /// サブの効果
        /// </summary>
        public IActivatable Sub { get; }
        
        
    }
}