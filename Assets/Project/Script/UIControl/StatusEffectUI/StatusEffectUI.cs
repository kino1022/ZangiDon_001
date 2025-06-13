using Project.Script.UIControl.Utility;
using R3;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Project.Script.UIControl.StatusEffectUI {
    public class StatusEffectUI : SerializedMonoBehaviour {
        
        [SerializeField, LabelText("表示名")]
        protected string m_effectName;
        
        [SerializeField, LabelText("表示時間")]
        protected float m_duration;

        protected TMPro.TMP_Text m_text;
        
        protected UiDestroyModule m_destroyModule;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="effectName">バフ/デバフ効果の名前</param>
        /// <param name="displayTime">表示時間</param>
        [Inject]
        public void Constructor(string effectName,float displayTime = 3.5f) {
            m_effectName = effectName;
            m_duration = displayTime;
        }

        private void Awake() {
            m_text = GetComponent<TMPro.TMP_Text>();
            m_text.text = m_effectName;
            
			m_destroyModule = new UiDestroyModule (this.gameObject,m_duration);
        }
        
        
    }
}