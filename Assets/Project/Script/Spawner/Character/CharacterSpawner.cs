using System.Collections.Generic;
using MessagePipe;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Project.Script.Scope;
using Teiwas.Script.EventBus;
using Teiwas.Script.Spawner.Character.Data;
using Teiwas.Script.Spawner.Enemy;
using Teiwas.Script.Spawner.Interface;
using Teiwas.Script.Spawner.Position.Interface;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Script.Spawner.Character {

    public class CharacterSpawner<T> : SerializedMonoBehaviour where T : CharacterSpawnerData {

        [OdinSerialize, LabelText("生成するオブジェクトのデータ")]
        protected T m_data;

        [OdinSerialize, LabelText("生成位置パターン")]
        protected ISpawnPositionManager m_pos;

        [OdinSerialize, LabelText("生成時に施す処理")]
        protected List<ISpawnDecorator> m_decorator = new List<ISpawnDecorator>();

        protected IPublisher<EntitySpown> m_publisher;

        [OdinSerialize, LabelText("DIコンテナ")]
        protected LifetimeScope m_lts;


        protected void Awake() {

            if(m_lts is null) {
                Debug.LogError($"{GetType()}にLifetimeScopeがアタッチされていませんでした");

                m_lts =
                    FindFirstObjectByType<GameLifeTimeScope>()
                    .GetComponent<GameLifeTimeScope>();

                if(m_lts is null) {
                    Debug.LogError($"シーン上にGameLifeTimeScopeを所持しているオブジェクトが存在していませんでした");
                    enabled = false;
                    return;
                }
            }

            if(m_pos is not null) {
                m_pos.Initialize(m_lts.Container, gameObject);
            }

            m_publisher = m_lts.Container.Resolve<IPublisher<EntitySpown>>();

            InitializeDecorator();
        }

        [Button("Execute Spawn")]
        public void Spawn() {

            if(m_data is null) {
                Debug.LogError($"{GetType()}に{typeof(T)}がセットされていません");
                return;
            }

            var pos = m_pos is null ? transform.position : m_pos.Position();

            var instance = m_lts.Container.Instantiate(m_data.Prefab, pos, transform.rotation);

            DecorateEntity(instance);

            m_publisher.Publish(new EntitySpown(instance, instance.transform.position));
        }

        public void SetPositionManager(ISpawnPositionManager pos) {
            m_pos = pos;
            m_pos.Initialize(m_lts.Container, gameObject);
        }

        protected void InitializeDecorator() {

            if(m_decorator.Count is 0 || m_decorator is null) {
                Debug.Log($"{GetType()}のエンティティ修飾リストが存在しないか要素がnullだったため初期化処理を中断します");
                return;
            }

            foreach(var item in m_decorator) {

                if(item is null) {
                    Debug.Log($"{GetType()}の要素{item.GetType()}がnullだったため処理を中断し、次の要素から初期化処理を行います");
                    continue;
                }

                item.Initialize(m_lts.Container, gameObject);
            }
        }


        protected void DecorateEntity(GameObject entity) {

            if(entity is null) {
                Debug.LogError($"{GetType()}でスポーンしたEntityがnullでした");
                return;
            }

            if(m_decorator.Count is 0 || m_decorator is null) {
                Debug.Log($"{GetType()}のエンティティ修飾リストが存在しないか要素がnullだったため修飾処理を中断します");
                return;
            }

            foreach(var item in m_decorator) {

                if(item is null) {
                    Debug.Log($"{GetType()}の要素{item.GetType()}がnullだったため処理を中断し、次の要素から修飾処理を行います");
                    continue;
                }

                item?.Decorate(entity);
            }
        }

        public void AddDecorator(ISpawnDecorator decorator) {
            if(decorator is not null) {
                decorator.Initialize(m_lts.Container, gameObject);
                m_decorator?.Add(decorator);
            }
        }
    }
}
