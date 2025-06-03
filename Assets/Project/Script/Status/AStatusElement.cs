using System;
using Project.Script.Status.Interface;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Status {
    /// <summary>
    /// ステータスの値という要素を管理するクラス
    /// </summary>
    [Serializable]
    public abstract class AStatusElement : IValueChangeHandler<float> {
        [OdinSerialize]
        protected float _value;
        
        protected float m_value {
            get { return _value; }
            set {
                _value = value;
                OnValueChanged();
                ValueChangeEvent?.Invoke(_value);
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