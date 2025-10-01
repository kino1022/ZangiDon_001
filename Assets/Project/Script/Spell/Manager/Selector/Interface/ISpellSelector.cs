using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Manager.Interface;
using Teiwas.Script.Spell.Slot.Selector.Interface;

namespace Teiwas.Script.Spell.Manager.Selector.Interface {
    /// <summary>
    /// プレイヤーの選択できるスペルを管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface ISpellSelector : ISpellManager<ISelectorSpellSlot, ISpellInstance> {

        /// <summary>
        /// スペルの選択
        /// </summary>
        /// <param name="index">何番目のスペルを選択するか</param>
        /// <returns>選択が成功したかどうか</returns>
        bool Select(int index);

        /// <summary>
        /// セレクターに対してのスペルの補充命令
        /// </summary>
        /// <param name="amount">補充する個数</param>
        void Supply(int amount);

    }
}
