using System;
using UnityEngine;

namespace Project.Script.Status {
    /// <summary>
    /// 補正後の値を管理するクラス
    /// </summary>
    [Serializable]
    public class CorrectedValueElements : AStatusElement {
        
        public CorrectedValueElements(float value) : base(value) {}
    }
}