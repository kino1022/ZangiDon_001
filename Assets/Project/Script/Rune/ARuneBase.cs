using System.Collections.Generic;
using System.Linq;
using Project.Script.Rune.Effect;
using Project.Script.Rune.Effect.Definition;
using Project.Script.Rune.Interface;
using Project.Script.Rune.Magic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Rune {
    /// <summary>
    /// 全てのルーンの基底クラス
    /// </summary>
    [CreateAssetMenu(menuName = "Project/Rune/Rune")]
    public class ARuneBase : SerializedScriptableObject {
        
        [Title("一文字目選択時に発動する魔術")]
        [OdinSerialize]
        protected AMagic m_magic = new AMagic();
        
        [Title("二文字目以降選択時の効果")]
        [ShowInInspector]
        [OdinSerialize]
        [SerializeField]
        protected SupportEffect m_effect = new SupportEffect();
        
        //------------------------API Methods--------------------------------
        
        
        //------------------------logical methods----------------------------
        

        
    }
}