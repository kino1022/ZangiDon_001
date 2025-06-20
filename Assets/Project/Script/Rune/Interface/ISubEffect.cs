using Teiwas.Script.Rune.Definition;
using UnityEngine;

namespace Teiwas.Script.Rune.Interface {
    /// <summary>
    /// 効果を発動できるクラスに対して約束するインターフェース
    /// </summary>
    public interface ISubEffect : IRuneEffect {

        public ActivateTiming GetTiming();
        
        public void Activate(GameObject caster);
        
    }
}