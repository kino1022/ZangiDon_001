using System;
using Teiwas.Script.Damage.Interface;

namespace Teiwas.Script.Damage.Factory.Interface {
    /// <summary>
    /// IDamageのインスタンスを生成するクラスに対して約束するインターフェース
    /// </summary>
    /// <typeparam name="Product">生成するダメージの型</typeparam>
    public interface IDamageFactory<Product> : IDisposable where Product : IDamage {
        
        /// <summary>
        /// IDamageのインスタンスを生成する
        /// </summary>
        /// <returns>生成されたインスタンス</returns>
        Product Create();
        
    }
}