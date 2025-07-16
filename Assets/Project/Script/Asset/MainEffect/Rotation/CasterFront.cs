using System;
using Sirenix.OdinInspector;
using Teiwas.Script.Asset.MainEffect.Interface;
using UnityEngine;

namespace Teiwas.Script.Asset.MainEffect.Rotation {
    [Serializable]
    [LabelText("生成方向：術者前方")]
    public class CasterFront : IInstanceRotationHolder {

        public Quaternion Rotation(GameObject caster) {

            return Quaternion.Euler(caster.transform.forward);
        }

    }
}
