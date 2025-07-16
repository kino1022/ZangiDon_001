using UnityEngine;

namespace Teiwas.Script.Motion.State.Context.Interface {
    public interface ICancelMotionContext {
        public void Update(int currentFrame);
        public bool Cancelable(AnimationClip motion);
    }
}
