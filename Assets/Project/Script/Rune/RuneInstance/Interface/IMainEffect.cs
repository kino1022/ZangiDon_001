using System;
using UnityEngine;

namespace Teiwas.Script.Rune.Interface {
    /// <summary>
    /// 発動する魔術の挙動を管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface IMainEffect : IRuneEffect {
        
        public Action<GameObject> OnCast { get; }
        
    }
}