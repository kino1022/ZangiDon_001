using System;
using Teiwas.Script.Damage.Interface;
using VContainer.Unity;

namespace Teiwas.Script.Damage.Processor.Interface {
    /// <summary>
    /// ダメージ処理を行うクラスに対して約束するインターフェース
    /// </summary>
    public interface IDamageProcessor : IStartable , IDisposable {
        /// <summary>
        /// ダメージの計算と適用を行う
        /// </summary>
        /// <param name="damage">与えるダメージ</param>
        /// <returns>計算と適用の成否</returns>
        bool Processing (IDamage damage);
    }
}