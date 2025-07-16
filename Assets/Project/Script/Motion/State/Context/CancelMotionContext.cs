using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Motion.State.Context.Element.Interface;
using Teiwas.Script.Motion.State.Context.Interface;
using Unity.Collections;
using UnityEngine;


namespace Teiwas.Script.Motion.State.Context {
    [Serializable]
    public class CancelMotionContext : ICancelMotionContext {

        [SerializeField, LabelText("無条件キャンセル")]
        protected bool m_cancelableAllMotion = false;

        [OdinSerialize, LabelText("キャンセル可能モーション")]
        protected List<ICancelMotionContextElement> m_elements = new List<ICancelMotionContextElement>();

        [SerializeField, LabelText("現在フレーム")]
        protected int m_currentFrame = 0;

        public void Update(int currentFrame) {

            if(currentFrame < 0) {
                throw new ArgumentOutOfRangeException();
            }

            m_currentFrame = currentFrame;
        }

        public bool Cancelable(AnimationClip motion) {

            if(motion is null) throw new ArgumentNullException(nameof(motion));

            if(m_cancelableAllMotion) return true;

            if(m_elements is null || m_elements.Count is 0) {
                return false;
            }

            foreach(var item in m_elements) {
                if(item.Cancelable(m_currentFrame, motion)) return true;
            }

            return false;
        }
    }
}
