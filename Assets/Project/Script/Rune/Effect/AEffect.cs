using Project.Script.Rune.Effect.Interface;
using Sirenix.OdinInspector;
using UnityCommonModule.Target.Interface;
using UnityEngine;

namespace Project.Script.Rune.Effect {
    public class AEffect<T> : AEffectBase {

        [Title("対象")] [InlineEditor(InlineEditorObjectFieldModes.Foldout)] [ShowInInspector] [SerializeReference]
        public ITargetHolder<T> Target;

        [Title("効果")] [InlineEditor(InlineEditorObjectFieldModes.Foldout)] [ShowInInspector] [SerializeReference]
        public IEffectExecutor<T> Executor;

        public virtual void OnActivate() {
            Executor.ExecuteEffect(Target.GetTarget());
        }
    }
}