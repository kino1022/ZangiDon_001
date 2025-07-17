using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Motion.State.Context.Element.Interface;
using Teiwas.Script.Motion.State.Context.Interface;
using UnityEngine;

namespace Teiwas.Script.Motion.State.Context {
    /// <summary>
    /// モーション中の自由落下の可否を示すクラス
    /// </summary>
    [Serializable]
    public class InMotionFreeFallContext : IInMotionFreeFallContext {

        [SerializeField, LabelText("無条件落下")]
        protected bool m_anytimeFall = false;

        [OdinSerialize, LabelText("データ")]
        protected List<IInMotionFreeFallContextElement> m_elements = new();

        [SerializeField, LabelText("現在フレーム")]
        protected int m_currentFrame = 0;


        public bool Fallable => CalculateFallable();

        public void Update(int currentFrame) {

            if(currentFrame < 0) {
                throw new ArgumentOutOfRangeException();
            }

            m_currentFrame = currentFrame;
        }

        protected bool CalculateFallable() {

            if(m_anytimeFall) {
                return true;
            }

            //リストが空なら落下可能として処理
            if(m_elements is null || m_elements.Count is 0) {
                return true;
            }

            foreach(var item in m_elements) {
                if(!item.Fallable(m_currentFrame)) return false;
            }

            return true;
        }
    }
}
