
using Project.Script.Rune.MainEffect;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Script.Rune {
    /// <summary>
    /// 全てのルーンの基底クラス
    /// </summary>
    public abstract class ARune : ScriptableObject {
        
        [SerializeField] public string runeName;
        
        [SerializeField] public Image RuneImage;
        
        [SerializeField] protected AMainEffect m_mainEffect;
        
        [SerializeField] protected SubEffect.SubEffect m_subEffect;
    }
}