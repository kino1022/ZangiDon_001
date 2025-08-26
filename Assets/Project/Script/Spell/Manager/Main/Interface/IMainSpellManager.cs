using Teiwas.Script.Spell.Instance.Main.Interface;
using Teiwas.Script.Spell.Manager.Interface;
using Teiwas.Script.Spell.Slot.Main.Interface;

namespace Teiwas.Script.Spell.Manager.Main.Interface {
    /// <summary>
    /// メインで選択されたスペルを管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface IMainSpellManager : ISpellManager<IMainSpellSlot, IMainSpellInstance> {
        
    }
}