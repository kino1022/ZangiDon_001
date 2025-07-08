using R3;
using UnityEngine;
using VContainer;

namespace Project.Script.Bullet.Destroy.Interface {
    /// <summary>
    /// 弾丸の消滅にかかる条件を管理するクラス
    /// </summary>
    public interface IDestroyCondition {
        /// <summary>
        /// 条件が満たされているかどうかの真偽値
        /// </summary>
        /// <returns></returns>
        public bool IsDestroy { get; }

        /// <summary>
        /// 条件判定の開始
        /// </summary>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public void Start(IObjectResolver resolver, GameObject bullet);
    }
}
