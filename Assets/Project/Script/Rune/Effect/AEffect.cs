using Project.Script.Rune.Effect.Definition;
using UnityEngine;

namespace Project.Script.Rune.Effect {
    /// <summary>
    /// ルーンの効果を記述するクラス
    /// </summary>
    public class AEffect : ScriptableObject {
        
        [SerializeField] public EffectTiming m_timing;
        
        
    }
}