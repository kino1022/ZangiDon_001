using Teiwas.Script.Spell.Instance.Interface;

namespace Teiwas.Script.Spell.Slot.Interface {
    /// <summary>
    ///　ゲーム中に存在する要素としてのスペルを管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface ISpellSlot {
        /// <summary>
        /// スロットが空かどうかの真偽値
        /// </summary>
        /// <value></value>
        bool IsEmpty { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        bool SetInstance(ISpellInstance instance);


        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        bool RemoveInstance();
    }
}
