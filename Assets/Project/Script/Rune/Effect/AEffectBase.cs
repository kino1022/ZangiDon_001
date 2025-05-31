using Project.Script.Rune.Effect.Definition;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Script.Rune.Effect {
    /// <summary>
    /// ルーンの効果を定義するクラスの基底クラス
    /// </summary>
    public abstract class AEffectBase : SerializedScriptableObject {
        /// <summary>
        /// 効果の発動するタイミング
        /// </summary>
        [SerializeField] public ActivateTiming Timing;
        
        /// <summary>
        /// 効果が発動した際の処理
        /// </summary>
        public virtual void OnActivate() {
            
        }
    }
}