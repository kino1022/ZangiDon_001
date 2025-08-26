using Teiwas.Script.Damage.Interface;

namespace Teiwas.Script.Damage.Processor.Interface {
    /// <summary>
    /// ダメージ計算に係るクラスに対して約束するインターフェース
    /// </summary>
    public interface IDamageProcessElement {
        
        /// <summary>
        /// 計算を行う
        /// </summary>
        /// <param name="damage">計算に参照するダメージ</param>
        /// <returns>計算の成否</returns>
        bool Process (IDamage damage);
    }
}