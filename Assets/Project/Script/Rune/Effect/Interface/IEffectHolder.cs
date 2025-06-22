using System;
using UnityEngine;

namespace Teiwas.Script.Rune.Effect.Interface {
    /// <summary>
    /// 対象に対して発動する効果の実処理を保持するクラスに対して約束するインターフェース
    /// </summary>
    public interface IEffectHolder  {
        /// <summary>
        /// 効果の処理
        /// </summary>
        /// <param name="target">対象になるオブジェクト</param>
        public void Apply(GameObject target);
    }
}