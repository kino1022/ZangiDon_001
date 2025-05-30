using Project.Script.Rune.Effect.Interface;
using UnityCommonModule.Target.Interface;
using UnityEngine;

namespace Project.Script.Rune.Effect {
    public class AEffect<T> : AEffectBase {

        [SerializeReference] public ITargetHolder<T> Target;

        [SerializeReference] public IEffectExecutor<T> Executor;

        public virtual void OnActivate() {
            Executor.ExecuteEffect(Target.GetTarget());
        }
    }
}