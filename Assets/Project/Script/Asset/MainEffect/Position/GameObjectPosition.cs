using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Asset.MainEffect.Interface;
using UnityEngine;

namespace Teiwas.Script.Asset.MainEffect.Position {
    [Serializable]
    [LabelText("生成位置:ゲームオブジェクト依存")]
    public class GameObjectPosition : IInstancePositionHolder {

        [SerializeField, LabelText("生成位置のオブジェクト")]
        protected GameObject m_obj;

        public Vector3 Position(GameObject caster) {
            return m_obj.transform.position;
        }
    }
}
