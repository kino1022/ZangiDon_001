using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Rune.Interface;
using UnityEngine;

namespace Teiwas.Script.Rune {
    public abstract class AMainEffectData : IMainEffectData {

        [OdinSerialize, LabelText("使用回数"), ProgressBar(0, 20)]
        protected int amount = 0;
        
        public int Amount => amount;
        
        public abstract void OnCast(GameObject caster);
    }
}