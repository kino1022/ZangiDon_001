using System;
using Project.Script.Rune.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Rune {
    /// <summary>
    /// 弾の射出を伴う魔術に使用するICastable
    /// </summary>
    [Serializable]
    public class MainEffectWithBullet: AMainEffect {
        
        [OdinSerialize, LabelText("生成するオブジェクト")] protected GameObject m_prefab;

        public override int GetAmount() {
            return amount;
        }
        
        public override void OnCast(GameObject caster) {
            
        }
    }
}