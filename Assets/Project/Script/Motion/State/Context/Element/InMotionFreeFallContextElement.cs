using System;
using Sirenix.OdinInspector;
using Teiwas.Script.Motion.State.Context.Element.Interface;
using UnityEngine;

namespace Teiwas.Script.Motion.State.Context.Element {
    [Serializable]
    public class InMotionFreeFallContextElement : IInMotionFreeFallContextElement {

        [SerializeField, LabelText("落下開始フレーム")]
        protected int m_start = Mathf.Min(0, 0);
        [SerializeField, LabelText("落下終了フレーム")]
        protected int m_end = Mathf.Min(0, 0);


        public bool Fallable(int currentFrame) {

            if(currentFrame < 0) {
                throw new ArgumentOutOfRangeException();
            }

            return m_start <= currentFrame && currentFrame >= m_end;
        }
    }
}
