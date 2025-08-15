using Teiwas.Script.Spell.Manager.Interface;
using Teiwas.Script.Spell.Slot.Interface;

namespace Teiwas.Script.Spell.Manager.Selector.Interface {
    /// <summary>
    /// プレイヤーが選択できるルーンを管理するクラスに対して約束するインターフェース
    /// </summary>
    /// <typeparam name="S"></typeparam>
    public interface ISpellSelector<S> : ISpellManager<S> where S : ISpellSlot, new() {
        /// <summary>
        /// 指定した番号のスペルを選択する
        /// </summary>
        /// <param name="index">スペルの場所(0からスタート)</param>
        /// <returns>選択して一連の動作が成功したか</returns>
        bool Select(int index);
    }
}
