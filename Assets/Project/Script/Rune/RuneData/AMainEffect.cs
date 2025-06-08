using Project.Script.Rune.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Rune {
    public abstract class AMainEffect : ICastable {

        [OdinSerialize, LabelText("使用回数"), ProgressBar(0, 20)] public int amount;
        
        
        public abstract int GetAmount();

        public abstract void OnCast(GameObject caster);
    }
}