using Project.Script.Rune.Interface;
using UnityEngine;

namespace Project.Script.Asset.Castable {
    public class DummyCastable : ICastable {
        public int GetAmount() {
            return 1;
        }

        public void OnCast(GameObject target) {}
    }
}