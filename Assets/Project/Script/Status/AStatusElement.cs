using System;
using Project.Script.Status.Interface;
using UnityEngine;

namespace Project.Script.Status {
    /// <summary>
    /// ステータスの値という要素を管理するクラス
    /// </summary>
    [Serializable]
    public class AStatusElement : IValueChangeHandler<float> {
        
        [SerializeField] protected float _value;

        protected float m_value {
            get { return _value; }
            set {
                m_value = value;
                OnValueChanged();
                ValueChangeEvent?.Invoke(m_value);
            }
        }
        
        public Action<float> ValueChangeEvent { get; set; }

        public AStatusElement(float value) {
            m_value = value;
        }
        
        //-------------------------API methods--------------------------

        public void Set(float value) {
            m_value = value;
            Debug.Log($"{value}にステータスの値を設定しました");
        }

        public void Increase(float value) {
            m_value += value;
            Debug.Log($"{value}をステータスの値に加算しました");
        }

        public void Decrease(float value) {
            m_value -= value;
            Debug.Log($"{value}をステータスの値に減算しました");
        }

        public float GetValue() {
            return m_value;
        }
        
        //-------------------------hook point---------------------------
        
        protected virtual void OnValueChanged () {}
    }
}