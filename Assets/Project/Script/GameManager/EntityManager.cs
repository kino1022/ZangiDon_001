using System;
using System.Linq;
using MessagePipe;
using ObservableCollections;
using Project.Script.Character;
using Sirenix.OdinInspector;
using Teiwas.Script.EventBus;
using Teiwas.Script.GameManager.Interface;
using UnityEngine;
using VContainer;

namespace Teiwas.Script.GameManager {
    /// <summary>
    /// インスタンスされている敵味方のGameObjectを管理するクラス
    /// </summary>
    public class EntityManager : SerializedMonoBehaviour, IEntityManager {

        [SerializeField, TitleGroup("存在しているEntity")]
        protected ObservableList<GameObject> m_entitys = new ObservableList<GameObject>();

        public IReadOnlyObservableList<GameObject> Entitys => m_entitys;

        protected ISubscriber<EntitySpown> m_spownSubscriber;

        protected ISubscriber<EntityDeath> m_deathSubscriber;

        protected IDisposable m_spownSubscriberDisposable;

        protected IDisposable m_deathSubscriberDisposable;

        [Inject]
        public void Construct(IObjectResolver resolver) {
            m_spownSubscriber = resolver.Resolve<ISubscriber<EntitySpown>>();
            m_deathSubscriber = resolver.Resolve<ISubscriber<EntityDeath>>();

            m_spownSubscriberDisposable = m_spownSubscriber.Subscribe(OnEntitySpown);
            m_deathSubscriberDisposable = m_deathSubscriber.Subscribe(OnEntityDeath);
        }

        private void Start() {
            InitializeEntityList();
        }

        protected void OnEntitySpown(EntitySpown message) {

            Debug.Log("EnemySpownを受け取りました。リストに追加します");

            if(message.Entity == null) {
                Debug.LogWarning("SpownしたEntityがnullです");
                return;
            }

            m_entitys.Add(message.Entity);
        }

        protected void OnEntityDeath(EntityDeath message) {
            Debug.Log("EntityDeathを受け取りました");

            if(m_entitys.Where(x => x == message.Entity).Equals(null)) {
                Debug.LogError("死亡した対象がリストに存在しませんでした");
                return;
            }

            m_entitys.Remove(message.Entity);
        }

        protected void InitializeEntityList() {
            var obj = FindObjectsOfType<AEntity>().ToList();

            if(obj.Count is 0 ) {
                Debug.Log("シーン上にエンティティが存在しませんでした");
                return;
            }

            foreach(var entity in obj) {
                m_entitys.Add(entity.Object);
            }
        }
    }
}
