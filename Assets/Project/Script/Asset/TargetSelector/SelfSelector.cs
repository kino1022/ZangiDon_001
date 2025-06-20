using System.Collections.Generic;
using Sirenix.OdinInspector;
using Teiwas.Script.Rune.Effect.Interface;
using UnityEngine;

namespace Teiwas.Script.Asset.TargetSelector {
    /// <summary>
    /// 自分を対象とするセレクター
    /// </summary>
    [LabelText("対象:自身")]
    public class SelfSelector : ITargetSelector {
        public List<GameObject> SelectTargets(GameObject caster) {
            return new List<GameObject>() { caster };
        }
    }
}