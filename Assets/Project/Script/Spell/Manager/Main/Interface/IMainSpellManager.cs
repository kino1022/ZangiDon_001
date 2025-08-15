using Teiwas.Script.Spell.Manager.Interface;
using Teiwas.Script.Spell.Slot.Main.Interface;

namespace Teiwas.Script.Spell.Manager.Main.Interface {
    /// <summary>
    /// メインに選択されたスペルを管理するクラスに対して約束するインターフェース
    /// </summary>
    /// <typeparam name="S"></typeparam>
    public interface IMainSpellManager<S> : ISpellManager<S> where S : IMainSpellSlot, new() {

    }
}
