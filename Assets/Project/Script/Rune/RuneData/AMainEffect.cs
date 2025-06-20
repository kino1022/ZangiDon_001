using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Rune.Interface;
using UnityEngine;

namespace Teiwas.Script.Rune {
    public abstract class AMainEffect : IMainEffect {

        [OdinSerialize, LabelText("使用回数"), ProgressBar(0, 20)] 
        public int amount;
        
        public abstract int GetAmount();

        public abstract void OnCast(GameObject caster);
    }
}