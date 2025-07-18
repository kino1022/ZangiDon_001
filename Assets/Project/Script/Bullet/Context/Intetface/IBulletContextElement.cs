using UnityEngine;

namespace Teiwas.Script.Bullet.Context.Intetface {
    /// <summary>
    /// 弾丸の動的変化する性能の要素を管理するクラス
    /// </summary>
    public interface IBulletContextElement {
        
        /// <summary>
        /// 同種のBulletContextElement同士で要素を加算する
        /// </summary>
        /// <param name="element"></param>
        public void AddElement (IBulletContextElement element);
        
    }
}