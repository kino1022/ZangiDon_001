using System;
using System.Collections.Generic;
using Project.Script.LockManage.Interface;
using Project.Script.Rune.Effect.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Asset.TargetSelector {
    [Serializable,LabelText("対象取得：円形範囲内")]
    public class RoundRangeTargetSelector : ITargetSelector {
        
        /// <summary>
        /// 取得できる限界範囲
        /// </summary>
        [OdinSerialize,LabelText("限界距離")] protected float m_rangeLimit = 200.0f;
        
        public List<GameObject> SelectTargets(GameObject caster) {
            var targets = new List<GameObject>();
            Collider[] colliders = Physics.OverlapSphere(caster.transform.position, m_rangeLimit);

            foreach (var collider in colliders) {
                targets.Add(collider.gameObject);
            }
            
            return targets;
        }
        
    }
}