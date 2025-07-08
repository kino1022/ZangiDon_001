using ObservableCollections;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Bullet.Context;
using Teiwas.Script.Bullet.Context.Intetface;
using Teiwas.Script.Rune.Manager.Interface;
using UnityEngine;
using VContainer;

namespace Project.Script.Character.Shoter {
    /// <summary>
    /// キャラクターのSubRuneから得られるRuneのIBulletContextを管理するクラス
    /// </summary>
    public class ContextManager : SerializedMonoBehaviour , IBulletContextHolder {
        
        [OdinSerialize]
        protected ISubRuneSlot m_slot;

        [OdinSerialize, LabelText("管理しているコンテキスト")]
        protected BulletContext m_context = new BulletContext();

        protected IObjectResolver m_resolver;

        public IBulletContext Context => m_context;
        
        [Inject]
        public void Construct(IObjectResolver resolver) {
            m_resolver = resolver;

            m_slot = m_resolver.Resolve<ISubRuneSlot>();

            if(m_slot == null) {
                Debug.Log($"{GetType().Name}でISubRuneSlotを継承したオブジェクトを取得できませんでした");
            }
            
            RegisterObserver();
        }

        protected void RegisterObserver() {
            
            m_slot?.List
                .ObserveChanged()
                .Subscribe(x => {
                    Debug.Log("ISubRuneListの変化を検知したのでContextの更新を行います");
                    OnListChanged();
                })
                .AddTo(this);
            
        }

        protected void OnListChanged() {
            m_context = new BulletContext();

            foreach (var rune in m_slot.List.Values) {
                m_context.Add(rune.Sub.Context);
            }
        }
    }
}