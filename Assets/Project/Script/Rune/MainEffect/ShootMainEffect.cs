using UnityEngine;

namespace Project.Script.Rune.MainEffect {
    /// <summary>
    /// 弾丸を伴うルーン魔術に対して与えるMainEffect
    /// </summary>
    [CreateAssetMenu(menuName = "Project/Rune/MainEffect/SingleShot")]
    public class ShootMainEffect : AMainEffect {
        /// <summary>
        /// 実体化するPrefab
        /// </summary>
        [SerializeField] protected GameObject m_prefab;
    }
}