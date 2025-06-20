using Teiwas.Script.Rune.Interface;
using Teiwas.Script.Rune;
using UnityEngine;

namespace Teiwas.Script.Asset.Castable {
    public class DummyCastable : AMainEffect {
        public override int GetAmount() {
            return amount;
        }

        public override void OnCast(GameObject target) {
            
        }
    }
}