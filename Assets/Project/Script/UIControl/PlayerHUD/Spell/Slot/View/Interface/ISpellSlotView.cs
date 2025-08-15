using System;
using VContainer.Unity;

namespace Teiwas.Script.UIControl.PlayerHUD.Spell.Slot.View.Interface {
    public interface ISpellSlotView : IStartable, IDisposable {
        void OnModelChanged();
    }
}
