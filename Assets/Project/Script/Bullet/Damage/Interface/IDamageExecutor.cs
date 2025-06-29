using UnityEngine;

namespace Project.Script.Bullet.Damage {
    /// <summary>
    /// 衝突した相手に対してダメージを与えるクラスに対して約束するインターフェース
    /// </summary>
    public interface IDamageExecutor {
        public void OnTriggerEnter(Collider other);
    }
}