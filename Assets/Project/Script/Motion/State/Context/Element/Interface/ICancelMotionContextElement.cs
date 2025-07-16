using UnityEngine;

namespace Teiwas.Script.Motion.State.Context.Element.Interface {
    public interface ICancelMotionContextElement {
        
        /// <summary>
        /// 現在のフレームで指定されたモーションにキャンセルできるかどうか
        /// </summary>
        /// <param name="currentFrame"></param>
        /// <param name="motion"></param>
        /// <returns></returns>
        public bool Cancelable(int currentFrame, AnimationClip motion);
    }
}
