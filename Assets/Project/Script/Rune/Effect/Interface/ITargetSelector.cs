using System.Collections.Generic;
using UnityEngine;

namespace Project.Script.Rune.Effect.Interface {
    /// <summary>
    /// 効果の対象を管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface ITargetSelector {
        /// <summary>
        /// 効果の対象になるオブジェクトを取得するメソッド
        /// </summary>
        /// <param name="caster">効果を発動するオブジェクト</param>
        /// <returns>対象になるオブジェクト</returns>
        public List<GameObject> SelectTargets (GameObject caster);
    }
}