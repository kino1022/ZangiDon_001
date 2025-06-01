using System;
using Project.Script.Interface;
using Project.Script.Rune.Effect.Definition;
using Project.Script.Rune.Effect.Interface;
using Sirenix.OdinInspector;
using UnityCommonModule.Target.Interface;
using UnityEngine;

namespace Project.Script.Rune.Effect {
    /// <summary>
    /// ルーンの効果を定義するクラスの基底クラス
    /// </summary>
    [Serializable]
    [CreateAssetMenu(menuName = "Project/Effect/Rune/RuneBase")]
    public class AEffectBase : SerializedScriptableObject {
        /// <summary>
        /// 効果の発動するタイミング
        /// </summary>
        [SerializeField] public ActivateTiming Timing;
        
        [Title("対象")] [InlineEditor(InlineEditorObjectFieldModes.Foldout)] [ShowInInspector] [SerializeReference]
        public ITargetHolder<GameObject> Target;

        [Title("効果")] [InlineEditor(InlineEditorObjectFieldModes.Foldout)] [ShowInInspector] [SerializeField]
        public IEffectExecutor<GameObject> Executor;
        
        /// <summary>
        /// 効果が発動した際の処理
        /// </summary>
        [Button("効果発動")]
        public virtual void OnActivate() {
            Executor.ExecuteEffect(Target.GetTarget());
        }
    }
}