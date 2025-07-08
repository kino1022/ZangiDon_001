using Project.Script.UIControl.PlayerHUD.Rune.Definition;
using Project.Script.UIControl.PlayerHUD.Rune.RuneUI.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Rune.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Script.UIControl.PlayerHUD.Rune.RuneUI {
    public class RuneUI : SerializedMonoBehaviour , IRuneUI {

        [SerializeField, LabelText("ルーンのスプライト")]
        protected Image m_sprite;

        [OdinSerialize, LabelText("ルーンの使用回数表示")]
        protected IRuneAmountUI m_amountUI;
        
        [OdinSerialize, LabelText("表示するルーン")]
        protected IRune m_rune;
        
        [SerializeField, LabelText("ルーンが配置されている場所")]
        protected RunePosition m_position;
        
        public RunePosition Position => m_position;

        private void Awake() {
            ViewUpdate();
        }
        
        public void Set(IRune rune) {
            Debug.Log($"{this.GetType().Name}に対して{rune.GetType().Name}がセットされました");
            InitializeUI();
            m_rune = null;
            m_rune = rune;
            
            #if UNITY_EDITOR
            if (m_rune.RuneSprite == null) {
                Debug.LogError($"{this.GetType().Name}内で{rune.GetType().Name}がセットされた際にスプライトが定義されていませんでした。");
            }
            #endif
            
            ViewUpdate();
        }

        public void Remove() {
            m_rune = null;
            
            ViewUpdate();
        }
        
        /// <summary>
        /// ルーンアイコン全体における描画の更新を行う
        /// </summary>
        protected void ViewUpdate() {
            SpriteUpdate();
            AmountUpdate();
        }

        protected void InitializeUI() {
            m_sprite.sprite = null;
        }
        
        /// <summary>
        /// スプライト要素の更新を行う
        /// </summary>
        protected virtual void SpriteUpdate() {
            m_sprite.enabled = true;
            
            //ルーンが何もない時の処理
            if (m_rune == null) {
                m_rune = null;
                m_sprite.sprite = null;
                m_sprite.enabled = false;
            }
            else {
                
                //スプライト定義がない際の例外処理
                if (m_rune.RuneSprite == null) {
                    Debug.Log($"{m_rune.GetType().Name}にルーンのスプライトが定義されていませんでした");
                    return;
                }
                
                m_sprite.sprite = m_rune.RuneSprite;
                m_sprite.SetNativeSize();
            }
        }
        
        /// <summary>
        /// 回数表示要素の更新を行う
        /// </summary>
        protected virtual void AmountUpdate() {
            
            if (m_rune == null) {
                m_amountUI.Remove();
                return;
            }

            if (m_position == RunePosition.Main) {
                m_amountUI.Set(m_rune.Main);
                return;
            }
            else if (m_position == RunePosition.Sub) {
                m_amountUI.Set(m_rune.Sub);
                return;
            }
            else {
                m_amountUI.Remove();
            }
        }
    }
}