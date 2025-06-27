using System.Collections.Generic;
using ObservableCollections;

namespace Teiwas.Script.Bullet.Context.Intetface {
    /// <summary>
    /// 生成する弾丸に対して加える補正などの特徴づけを保持するクラス
    /// </summary>
    public interface IBulletContext {

        public IReadOnlyObservableList<IBulletContextElement> Elements { get;}
        
        /// <summary>
        /// Contextの統合を行う
        /// </summary>
        /// <param name="context"></param>
        public void Add(IBulletContext context);
        
    }
}