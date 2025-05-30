using UnityCommonModule.Correction;

namespace Project.Script.Status.Interface {
    /// <summary>
    /// 補正可能なクラスに対して約束するインターフェース
    /// </summary>
    public interface ICorrectable {
        /// <summary>
        /// 与えられた補正値で補正するメソッド
        /// </summary>
        /// <param name="correction"></param>
        public void Correct (ACorrection correction);
    }
}