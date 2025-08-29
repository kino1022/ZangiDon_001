using Teiwas.Script.Spell.Data.Interface;
using Teiwas.Script.Spell.Effect.Interface;
using UnityEngine.Analytics;
using VContainer.Unity;

namespace Teiwas.Script.Spell.Factory.Pattern.Interface {
    /// <summary>
    ///  ISpellFactoryでの生成パターンを管理するクラスに対して約束するインターフェース
    /// </summary>
    /// <typeparam name="Data"></typeparam>
    public interface ISpellLotteryPattern<Data> : IStartable
        where Data : ISpellData {
        Data GetCreateData();
    }
}
