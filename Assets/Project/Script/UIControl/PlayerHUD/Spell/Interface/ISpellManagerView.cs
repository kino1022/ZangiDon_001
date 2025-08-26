using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Slot.Interface;
using Teiwas.Script.UIControl.PlayerHUD.Spell.Slot;
using VContainer.Unity;

namespace Teiwas.Script.UIControl.PlayerHUD.Spell.Interface {
    
    /// <summary>
    /// UIにSpellManagerを描画する際のデータを管理するクラスに対して約束するインターフェース
    /// </summary>
    /// <typeparam name="Slot"></typeparam>
    /// <typeparam name="Instance"></typeparam>
    public interface ISpellManagerView<Slot, Instance> : IStartable, IDisposable 
        where Slot :　ISpellSlot<Instance> 
        where Instance : ISpellInstance {

        Dictionary<int, ISpellSlotUIView> Spells { get; set; }

    }
}