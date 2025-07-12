using ObservableCollections;
using Project.Script.Utility;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Bullet.Context;
using Teiwas.Script.Bullet.Context.Intetface;
using Teiwas.Script.Rune.Manager.Interface;
using UnityEngine;
using VContainer;

namespace Teiwas.Script.Character.Shoter {
    /// <summary>
    /// キャラクターのSubRuneから得られるRuneのIBulletContextを管理するクラス
    /// </summary>
    [DefaultExecutionOrder(9999)]
    public class ContextManager : SerializedMonoBehaviour, IBulletContextHolder {
        [OdinSerialize, LabelText("生成物に渡すContext")]
        protected IBulletContext m_context = new BulletContext();

        public IBulletContext Context => m_context;

        [OdinSerialize, LabelText("参照するサブルーン")]
        protected ISubRuneSlot m_slot;

        protected IObjectResolver m_resolver;

        [Inject]
        public void Construct(IObjectResolver resolver) {
            m_resolver = resolver;

            if(m_resolver == null) {
                Debug.LogError("IObjectResolverを取得できませんでした");
                return;
            }
        }

        private void Start() {
            m_slot = m_resolver?.Resolve<ISubRuneSlot>();

            if(m_slot == null) {
                Debug.LogError("IObjectResolverからISubRuneSlotを取得できませんでした。GetComponentを試行します");

                var root = transform.parent.root;

                m_slot = root.GetComponentInChildren<ISubRuneSlot>();

                if(m_slot == null) {
                    Debug.Log($"{gameObject.name}全体からISubRuneSlotから取得できませんでした");
                    return;
                }
            }

            ObserveRuneList();
        }

        protected void ObserveRuneList() {
            m_slot.List
                .ObserveChanged()
                .Subscribe(x => {
                    Debug.Log($"{m_slot.GetType()}でルーンの変化を検知したため、Contextの更新を行います");
                    UpdateContext();
                })
                .AddTo(this);
        }

        protected void UpdateContext() {
            m_context = new BulletContext();

            foreach(var item in m_slot.List) {
                var con = item.Value.Sub.Context;

                m_context.Add(con);
            }
        }
    }
}
