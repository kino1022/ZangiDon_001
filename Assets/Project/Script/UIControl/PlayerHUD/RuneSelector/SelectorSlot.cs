using System;
using Project.Script.Rune.Interface;
using Project.Script.Rune.Manager.Interface;
using Project.Script.UIControl.PlayerHUD.RuneSelector.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine.UI;

namespace Project.Script.UIControl.PlayerHUD.RuneSelector {
    [Serializable]
    public class SelectorSlot : SerializedMonoBehaviour, ISelectorSlot {
        
        protected IRune m_rune;
        
        public IRune Rune => m_rune;
        
        [OdinSerialize,LabelText("ルーンのスプライト")]
        protected Image m_runeSprite;
        
        [OdinSerialize, LabelText("メイン効果の背景")]
        protected Image m_mainBackGround;
        
        [OdinSerialize, LabelText("サブ効果の背景")]
        protected Image m_subBackGround;
        

        public void Set(IRune rune) {
            m_rune = rune;
            UpdateSprite();
        }

        public void Remove() {
            m_rune = null;
            UpdateSprite();
        }
        
        /// <summary>
        /// 現在保持しているルーンの状態に合わせて描画を更新する
        /// </summary>
        protected void UpdateSprite() {
            m_runeSprite.sprite = m_rune.RuneSprite;
        }
    }
}