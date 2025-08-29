using System;
using R3;
using Teiwas.Script.Spell.Instance.Module.Interface;

namespace Teiwas.Script.Spell.Instance.Module {
    [Serializable]
    public class AmountCounter : IAmountCounter {

        protected ReactiveProperty<int> m_maxAmount;

        protected ReactiveProperty<int> m_amount;
        
        public ReadOnlyReactiveProperty<int> Max => m_maxAmount;
        
        public ReadOnlyReactiveProperty<int> Current => m_amount;

        public AmountCounter(int amount) {
            m_maxAmount = new ReactiveProperty<int>(amount);
            m_amount = new ReactiveProperty<int>(m_maxAmount.Value);
        }

        public void Dispose() {
            
        }

        public void Increase(int amount) {
            throw new NotImplementedException();
        }

        public void Decrease(int amount) {
            throw new NotImplementedException();
        }
    }
}