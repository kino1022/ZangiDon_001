using System.Collections.Generic;
using System.Linq;
using ObservableCollections;
using Project.Script.Utility;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Character.Group.Interface;
using Teiwas.Script.GameManager.Interface;
using UnityEngine;
using VContainer;

namespace Project.Script.Character.Group {
    public class GroupEntityManager : SerializedMonoBehaviour, IGroupEntityManager {

        [OdinSerialize, LabelText("グループごとの属するエンティティ")]
        protected ObservableDictionary<IGroup, List<GameObject>> m_group = new ObservableDictionary<IGroup, List<GameObject>>();

        public IReadOnlyObservableDictionary<IGroup, List<GameObject>> GroupEntity => m_group;

        protected IEntityManager m_entityManager;

        protected IReadOnlyObservableList<GameObject> m_entities => m_entityManager.Entitys;

        protected IObjectResolver m_resolver;

        public void Construct(IObjectResolver resolver) {
            m_resolver = resolver;

            m_entityManager = resolver.Resolve<IEntityManager>();

            if(m_entityManager is null) {
                Debug.LogError($"{GetType().Name}でIEntityManagerを取得できませんでしたInjectionを終了します");
                return;
            }

            InitializeDictionaries();
            ObserveEntityManager();
        }

        protected void InitializeDictionaries() {

            if(m_entities is null) {
                Debug.LogError($"{GetType().Name}で取得したIEntityManagerがnullでした");
                return;
            }

            if(m_entities.Count is 0) {
                Debug.Log($"{m_entityManager.GetType().Name}のリストが空の為{GetType().Name}の初期化処理を中断します");
                return;
            }

            foreach(var entity in m_entities) {
                AddEntity(entity);
            }
        }

        protected void ObserveEntityManager() {

            if(m_entityManager is null) {
                Debug.LogError($"{GetType().Name}でIEntityManagerを参照できません");
                return;
            }

            m_entities
                .ObserveAdd()
                .Subscribe(x => {
                    Debug.Log($"{m_entityManager.GetType().Name}で要素の追加を検知した為{GetType().Name}で要素の追加を開始します");
                    OnAddEntity(x);
                })
                .AddTo(this);

            m_entities
                .ObserveRemove()
                .Subscribe(x => {
                    Debug.Log($"{m_entityManager.GetType().Name}で要素の除外を検知した為{GetType().Name}で要素の除外を開始します");
                    OnRemoveEntity(x);
                })
                .AddTo(this);

        }

        protected void OnAddEntity(CollectionAddEvent<GameObject> x) {

        }

        protected void OnRemoveEntity(CollectionRemoveEvent<GameObject> x) {

            if(x.Value is null) {
                Debug.Log($"");
                return;
            }

            RemoveEntity(x.Value);
        }

        protected void AddEntity(GameObject entity) {
            var groupHolder =
                ComponentsUtility.GetComponentFromWhole<IGroupHolder>(entity.transform.root.gameObject);

            if(groupHolder is null) {
                Debug.LogError($"{entity.name}はIGroupHolderを継承したコンポーネントを持っていませんでした");
                return;
            }

            var groups = groupHolder.Groups;

            foreach(var group in groups) {
                if(m_group.ContainsKey(group) == false) {
                    m_group.Add(group, new List<GameObject>());
                }
                var value = m_group.FirstOrDefault(x => x.Key == group).Value;
                value.Add(entity);
            }
        }

        protected void RemoveEntity(GameObject entity) {

            foreach(var group in m_group) {
                foreach(var item in group.Value) {
                    if(entity == item) {
                        Debug.Log($"{m_entityManager.GetType().Name}で指定の要素を発見した為除外処理を開始します");
                        m_group.Remove(group.Key);

                        if(group.Value.Count is 0) {
                            Debug.Log($"{m_entityManager.GetType().Name}の{group.Key.GetType().Name}の要素が空になった為辞書から除外します");
                            m_group.Remove(group.Key);
                        }
                        break;
                    }
                }
            }


        }
    }
}
