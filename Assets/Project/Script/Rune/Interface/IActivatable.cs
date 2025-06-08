using Project.Script.Rune.Definition;
using UnityEngine;

namespace Project.Script.Rune.Interface {
    /// <summary>
    /// 効果を発動できるクラスに対して約束するインターフェース
    /// </summary>
    public interface IActivatable {
        
        public ActivateTiming timing {get; set;}

        public int GetAmount();
        
        public void Activate(GameObject caster);
    }
}