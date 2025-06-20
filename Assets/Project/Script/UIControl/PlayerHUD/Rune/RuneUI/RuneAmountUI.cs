using Project.Script.UIControl.PlayerHUD.Rune.RuneUI.Interface;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Rune.Interface;
using UnityEngine;

namespace Project.Script.UIControl.PlayerHUD.Rune.RuneUI {
    public class RuneAmountUI : SerializedMonoBehaviour , IRuneAmountUI {
        
        [OdinSerialize, LabelText("使用回数の参照先")]
        protected IRuneEffect m_effect;
        
        [SerializeField, LabelText("TMP.Text")]
        protected TMPro.TMP_Text m_text;

        private int _amount;
        
        protected CompositeDisposable m_disposable = new CompositeDisposable();

        protected int m_amount {
            get => _amount;
            set => _amount = value;
        }

        public void Set(IRuneEffect effect) {
            if (m_effect != null) {
                Remove();
            }
            
            m_effect = effect;
            RegisterObserveAmount();
        }

        public void Remove() {
            m_effect = null;
            m_text.text = "Empty";
        }

        protected void RegisterObserveAmount() {
            Observable.EveryValueChanged(m_effect, effect => effect.GetAmount()).Subscribe(x => {
                Debug.Log("ルーンの使用回数の変化を検知しました");
                OnRuneAmountChange(x);
            }).AddTo(m_disposable);
        }

        protected void OnRuneAmountChange(int amount) {
            m_amount = amount;
            m_text.text = amount.ToString();
        }
    }
}