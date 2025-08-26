using System;
using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Slot.Interface;
using VContainer.Unity;

namespace Teiwas.Script.UIControl.PlayerHUD.Spell.Slot {
    public interface ISpellSlotPresenter<Slot, Instance> : IStartable , IDisposable 
        where Slot : ISpellSlot<Instance>
        where Instance : ISpellInstance
    {
        
    }
}