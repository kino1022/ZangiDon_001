using Project.Script.UIControl.PlayerHUD.Rune.Definition;
using Project.Script.UIControl.PlayerHUD.Rune.RuneUI.Interface;
using Sirenix.OdinInspector;
using Teiwas.Script.Rune.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Script.UIControl.PlayerHUD.Rune.RuneUI {
    public class RuneUI : SerializedMonoBehaviour , IRuneUI {

        [SerializeField, LabelText("ルーンのスプライト")]
        protected Image m_sprite;

        [SerializeField, LabelText("ルーンの使用回数表示")]
        protected IRuneAmountUI m_amountUI;
        
        [SerializeField, LabelText("表示するルーン")]
        protected IRune m_rune;
        
        [SerializeField, LabelText("ルーンが配置されている場所")]
        protected RunePosition m_position;
        
        public RunePosition Position => m_position;
        
        public void Set(IRune rune) {
            m_rune = rune;
            
            UpdateView();
        }

        public void Remove() {
            m_rune = null;
        }

        protected void UpdateView() {
            m_sprite.sprite = m_rune.RuneSprite;
            m_sprite.SetNativeSize();
            
            if (m_position == RunePosition.Main) {
                m_amountUI.Set(m_rune.Main);
            }
            else if (m_position == RunePosition.Sub) {
                m_amountUI.Set(m_rune.Sub);
            }
            else {
                m_amountUI.Remove();
            }
            
        }
    }
}