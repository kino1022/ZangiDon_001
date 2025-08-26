using UnityEngine;

namespace Teiwas.Script.Spell.Effect.Interface {
    /// <summary>
    /// サブスペルの持つ効果を表現するクラスに対して約束するインターフェース
    /// </summary>
    public interface ISpellEffect {

        /// <summary>
        /// 効果を発動させる処理
        /// </summary>
        /// <param name="caster">術者のオブジェクト</param>
        public void OnActivate(GameObject caster);
        
    }
}