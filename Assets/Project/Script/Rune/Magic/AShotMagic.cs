using System;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Rune.Magic {
    /// <summary>
    /// 何かしらのインスタンスを伴う魔術の基底クラス
    /// </summary>
    [Serializable]
    public class AInstanceMagic : AMagic {
        /// <summary>
        /// インスタンスするオブジェクト
        /// </summary>
        [OdinSerialize] protected GameObject m_prefab;
    }
}