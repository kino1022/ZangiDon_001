using System.Collections.Generic;
using Project.Script.Rune.Effect.Interface;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Script.Asset.TargetSelector {
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