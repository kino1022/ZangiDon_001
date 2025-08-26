using System.Collections.Generic;
using Teiwas.Script.Damage.Tag.Interface;

namespace Teiwas.Script.Damage.Interface {
    /// <summary>
    /// タグ付きで表現されるダメージに対して約束するインターフェース
    /// </summary>
    public interface IDamageWithTag : IDamage {
        
        /// <summary>
        /// ダメージが保持するタグ
        /// </summary>
        List<IDamageTag> Tags { get; }
        
        /// <summary>
        /// 指定したタグをダメージに対して追加する
        /// </summary>
        /// <param name="tag">追加するタグ</param>
        /// <returns>追加に成功したか</returns>
        bool AddTag (IDamageTag tag);
        
        /// <summary>
        /// 指定したタグをダメージから除外する
        /// </summary>
        /// <param name="tag">除外するタグ</param>
        /// <returns>除外に成功したか</returns>
        bool RemoveTag (IDamageTag tag);
        
        
    }
}