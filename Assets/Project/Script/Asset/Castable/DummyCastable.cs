using Project.Script.Rune;
using Project.Script.Rune.Interface;
using UnityEngine;

namespace Project.Script.Asset.Castable {
    public class DummyCastable : AMainEffect {
        public override int GetAmount() {
            return amount;
        }

        public override void OnCast(GameObject target) {
            
        }
    }
}