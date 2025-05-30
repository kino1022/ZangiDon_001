using UnityEngine;

namespace Project.Script.Status {
    /// <summary>
    /// 補正後の値を管理するクラス
    /// </summary>
    [SerializeField]
    public class CorrectedValueElements : AStatusElement {
        
        public CorrectedValueElements(float value) : base(value) {}
    }
}