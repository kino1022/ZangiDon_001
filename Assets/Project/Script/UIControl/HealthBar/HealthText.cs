using Project.Script.UIControl.HealthBar.Interface;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using TMPro;

namespace Project.Script.UIControl.HealthBar {
    public class HealthText : SerializedMonoBehaviour {
        
        [OdinSerialize] protected IStatusInstanceHolder m_instance;
        
        [OdinSerialize] protected TextMeshPro m_text;

        protected int m_max = 0;
        
        protected int m_current = 0;
        
        private void Start() {
            
            Observable
                .EveryValueChanged(m_instance.Max, i => m_instance.Max.GetValue())
                .Subscribe(i => m_max = i)
                .AddTo(gameObject);
                
            Observable
                .EveryValueChanged(m_instance.Current, i => m_instance.Current.GetValue())
                .Subscribe(i => m_current = i)
                .AddTo(gameObject);
            
        }

        private void Update() {
            
            var text = $"{m_current} / {m_max}";
            m_text.text = text;
            
        }
    }
}