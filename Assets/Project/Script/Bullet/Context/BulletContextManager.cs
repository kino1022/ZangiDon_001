using System;
using System.Collections.Generic;
using Project.Script.Utility;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Bullet.Context.Intetface;
using VContainer;

namespace Teiwas.Script.Bullet.Context {
    /// <summary>
    /// 弾丸の生成時にIBulletContextを受け取って各コンポーネントに反映させるクラス
    /// </summary>
    public class BulletContextManager : SerializedMonoBehaviour {
        
        [OdinSerialize, LabelText("受け取ったコンテキスト")]
        protected IBulletContext m_context;

        [OdinSerialize, LabelText("適用先オブジェクト")]
        protected IBulletContextApplicable m_apply;
        
        

        [Inject]
        public void Construct(IBulletContextHolder contextHolder) {
            m_context = contextHolder.Context;
        }


        public void ApplyContext() {
            
        }
    }
}