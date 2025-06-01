using System;
using Project.Script.Rune;
using UnityEngine;

namespace Project.Script.RuneManage {
    [Serializable]
    public class SelectorSlot {
        /// <summary>
        /// スロットにセットされているルーン
        /// </summary>
        [SerializeField] public ARuneBase rune;
        
        /// <summary>
        /// 再補充までの時間
        /// </summary>
        [SerializeField] public float resupplyTime;

        public SelectorSlot(ARuneBase rune, float resupplyTime) {
            this.rune = rune;
            this.resupplyTime = resupplyTime;
        }
        
        //-------------------API methods---------------------------
        
        
    }
}