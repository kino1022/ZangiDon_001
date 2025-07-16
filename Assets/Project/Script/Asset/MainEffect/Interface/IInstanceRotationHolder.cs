using UnityEngine;

namespace Teiwas.Script.Asset.MainEffect.Interface {
    public interface IInstanceRotationHolder {
        public Quaternion Rotation(GameObject caster);
    }
}
