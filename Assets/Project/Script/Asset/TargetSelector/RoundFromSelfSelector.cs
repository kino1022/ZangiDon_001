using System;
using System.Collections.Generic;
using Sirenix.Serialization;
using Teiwas.Script.Rune.Effect.Interface;
using Unity.VisualScripting;
using UnityEngine;

namespace Teiwas.Script.Asset.TargetSelector {
    /// <summary>
    /// 自分を中心とした球状範囲内にいるゲームオブジェクトを対象に取る
    /// </summary>
    [Serializable]
    public class RoundFromSelfSelector : ITargetSelector {
        
        [OdinSerialize, SerializeField] protected float range;
        
        public List<GameObject> SelectTargets(GameObject caster) {
            return null;
        }
    }
}