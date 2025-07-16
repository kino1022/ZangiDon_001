using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Teiwas.Script.Motion.State.Context.Element.Interface;
using UnityEngine;


namespace Teiwas.Script.Motion.State.Context.Element {
    [Serializable]
    public class CancelMotionContextElement : ICancelMotionContextElement {

        [SerializeField, LabelText("受付開始フレーム")]
        protected int m_start = Mathf.Min(0, 0);

        [SerializeField, LabelText("受付終了フレーム")]
        protected int m_end = Mathf.Min(0, 0);

        [SerializeField, LabelText("全フレーム受付")]
        protected bool m_anyFrameCancel = false;

        [SerializeField, LabelText("キャンセルモーション")]
        protected List<AnimationClip> m_motions = new();

        public bool Cancelable(int currentFrame, AnimationClip motion) {

            if(motion is null) {
                throw new ArgumentNullException();
            }

            var exist = !m_motions.Where(x => x.name == motion.name).Equals(null);

            if(!exist) return false;

            return m_start <= currentFrame && currentFrame >= m_end;
        }


    }
}
