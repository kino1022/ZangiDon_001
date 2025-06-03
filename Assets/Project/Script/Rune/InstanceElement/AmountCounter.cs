using System;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Rune.InstanceElement {
    [Serializable]
    public class AmountCounter {
        
        [OdinSerialize,SerializeField] protected int m_maxAmount;
        
        [OdinSerialize,SerializeField] private int _currentAmount;

        protected int m_currentAmount {
            get { return _currentAmount; }
            set {
                m_currentAmount = value;
                OnAmountChanged();
            }
        }

        public Action AmountZeroEvent { get; set; }

        public AmountCounter(int maxAmount) {
            m_maxAmount = maxAmount;
        }

        #region API methods

        #region CurrentAmount

        public int GetCurrentAmount() {
            return m_currentAmount;
        }

        public void SetCurrentAmount(int amount) {
            m_currentAmount = amount;
        }

        public void IncreaseAmount(int value) {
            m_currentAmount += value;
        }

        public void DecreaseAmount(int value) {
            m_currentAmount -= value;
        }

        #endregion

        #region MaxAmount

        public int GetMaxAmount() {
            return m_maxAmount;
        }

        public void SetMaxAmount(int value) {
            m_maxAmount = value;
            if (m_maxAmount < _currentAmount) {
                Debug.Log("最大使用回数が現在使用回数を下回ったため、現在使用回数を最大使用回数で初期化します");
                _currentAmount = m_maxAmount;
            }
        }

        #endregion
        #endregion
        
        #region Hook Points
        
        /// <summary>
        /// 使用回数が変化した際に呼び出されるメソッド
        /// </summary>
        protected virtual void OnAmountChanged() {

            if (m_currentAmount <= 0) {
                OnBecameAmountZero();
                return;
            }
            
            if (m_currentAmount > m_maxAmount) {
                Debug.Log("現在使用回数が最大使用回数を上回ったため、最大使用回数で現在使用回数を初期化します");
            }
        }
        
        /// <summary>
        /// 使用回数が0になった際に呼び出されるメソッド
        /// </summary>
        protected virtual void OnBecameAmountZero() {
            AmountZeroEvent?.Invoke();
        }
        
        #endregion
        
    }
}