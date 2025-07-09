using MessagePipe;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Enemy.Data;
using Teiwas.Script.EventBus;
using Teiwas.Script.Spawner.Interface;
using Teiwas.Script.Spawner.Position.Interface;
using UnityEngine;
using VContainer;

namespace Teiwas.Script.Spawner.Enemy {
    public class EnemySpawner : SerializedMonoBehaviour, ISpawner {

        [SerializeField, LabelText("生成するエネミーのデータ")]
        protected EnemyData m_data;

        [OdinSerialize, LabelText("スポーン位置制御")]
        protected ISpawnPositionManager m_pos;

        protected IPublisher<EntitySpown> m_publisher;

        private IObjectResolver m_resolver;

        [Inject]
        public void Construct(IObjectResolver resolver) {
            m_resolver = resolver;

            if(m_resolver == null) {
                Debug.LogError($"{gameObject.name}の{GetType()}でIObjectResolverが取得できませんでした");
                return;
            }

            m_publisher = resolver.Resolve<IPublisher<EntitySpown>>();

            if(m_publisher == null) {
                Debug.LogError($"{gameObject.name}の{GetType()}でIPublisher<EntitySpown>が取得できませんでした");
            }
        }


        private void Awake() {
            m_pos?.Initialize(m_resolver, gameObject);
        }


        public void Spawn() {

            if(m_pos == null) {
                Debug.Log($"{gameObject.name}の{GetType()}でPositionManagerが取得できない為、{gameObject.name}と同一座標に{m_data.EnemyPrefab.name}をスポーンさせます");
            }

            var pos = m_pos == null ? gameObject.transform.position : m_pos.Position();

            var instance = GameObject
                                .Instantiate(
                                    m_data.EnemyPrefab,
                                    pos,
                                    gameObject.transform.rotation
                                    );

            m_publisher.Publish(new EntitySpown(instance, instance.transform.position));
        }

        public void SetPositionManager(ISpawnPositionManager posManager) {
            m_pos = posManager;

            m_pos?.Initialize(m_resolver, gameObject);
        }


        public void SetEnemyData(EnemyData data) {
            if(data.EnemyPrefab == null) {
                Debug.LogError($"{data.name}はGameObjectの指定がない不正なデータです。ハブりますね");
                return;
            }

            m_data = data;
        }
    }
}
