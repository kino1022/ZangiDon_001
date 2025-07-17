using UnityEngine;

namespace Teiwas.Script.EventBus.Character {

    public readonly struct ChangeAnimation {

        public readonly GameObject Object;

        public readonly AnimationClip Animation;

        public ChangeAnimation(GameObject obj,AnimationClip clip) {
            Object = obj;
            Animation = clip;
        }
    }
}
