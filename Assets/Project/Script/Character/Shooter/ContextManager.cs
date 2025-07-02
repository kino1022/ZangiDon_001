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

        public IBulletContext Context => m_context;
        
        [Inject]
        public void Construct(ISubRuneSlot slot) {
            m_slot = slot;

            if (m_slot == null) {
                Debug.LogError("ISubRuneSlotが正常に取得できませんでした");
                return;
            }
            
            RegisterObserver();
        }

        protected void RegisterObserver() {
            
            m_slot.List
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