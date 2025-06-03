using UnityEngine;

namespace Project.Script.Rune.Interface {
    /// <summary>
    /// 発動する魔術の挙動を管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface ICastable {
        
        /// <summary>
        /// 使用可能回数を返すメソッド
        /// </summary>
        /// <returns></returns>
        public int GetAmount();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="caster"></param>
        public void OnCast(GameObject caster);
        
    }
}