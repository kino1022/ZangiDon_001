using UnityEngine;

namespace Teiwas.Script.Rune.Interface {
    /// <summary>
    /// 発動する魔術の挙動を管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface IMainEffect : IRuneEffect {
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="caster"></param>
        public void OnCast(GameObject caster);
        
    }
}