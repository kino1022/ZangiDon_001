using System;
using R3;

namespace Teiwas.Script.Spell.Instance.Module.Interface {
    public interface IAmountCounter : IDisposable {

        ReadOnlyReactiveProperty<int> Max { get; }

        ReadOnlyReactiveProperty<int> Current { get; }

        void Increase(int amount);

        void Decrease(int amount);
        
        
    }
}
