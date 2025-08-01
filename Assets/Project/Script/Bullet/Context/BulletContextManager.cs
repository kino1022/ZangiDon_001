using System;
using System.Collections.Generic;
using System.Linq;
using Project.Script.Utility;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Bullet.Context.Intetface;
using UnityEngine;
using VContainer;

namespace Teiwas.Script.Bullet.Context {
    /// <summary>
    /// 弾丸の生成時にIBulletContextを受け取って各コンポーネントに反映させるクラス
    /// </summary>
    public class BulletContextManager : SerializedMonoBehaviour {

        [OdinSerialize, LabelText("受け取ったコンテキスト")]
        protected IBulletContext m_context;

        [OdinSerialize, LabelText("適用先オブジェクト")]
        protected List<IBulletContextApplicable> m_apply;

        [OdinSerialize, LabelText("IBulletContextHolder")]
        protected IBulletContextHolder m_holder;

        [Inject]
        public void Construct(IObjectResolver resolver) {
            m_holder = resolver.Resolve<IBulletContextHolder>();
        }

        private void Awake() {
            m_context = m_holder.Context;

            if(m_context == null) {
                Debug.LogError("取得したIBulletContextがnullでした");
            }

            m_apply = ComponentsUtility.GetComponentsFromWhole<IBulletContextApplicable>(gameObject);

            if (m_apply.Count == 0) {
                Debug.LogError("IBulletContextApplicableを継承したオブジェクトを取得できませんでした");
                return;
            }

            ApplyContext();

        }

        public void ApplyContext() {

            if (m_context == null) {
                Debug.LogError($"コンテキストが保持されていません、ルーンにコンテキストが定義されていないか、コンテキストの受け渡しが行われていません");
                return;
            }

            foreach (var apply in m_apply) {
                apply.Apply(m_context);
            }
        }
    }
}
