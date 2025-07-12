using Cysharp.Threading.Tasks;
using ObservableCollections;
using Project.Script.LockManage;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.GameManager.Interface;
using Unity.Collections;
using UnityEngine;
using VContainer;
using R3;
using Teiwas.Script.Character.LockManage.Interface;
using Unity.VisualScripting;

namespace Teiwas.Script.Character.LockManager {
    public class PlayerTargetSelector : SerializedMonoBehaviour , ILockTargetSelector {

        protected bool m_changeable = true;

        protected IEntityManager m_entityManager;

        //現在インスタンスされているEntityのリスト
        protected IReadOnlyObservableList<GameObject> m_entities => m_entityManager?.Entitys;

        protected ILockTargetHolder m_targetHolder;

        protected IObjectResolver m_resolver;

        #region Interface Field

        public bool Changeable {
            get => m_changeable;
            set => m_changeable = value;
        }

        #endregion

        public void Construct(IObjectResolver resolver) {

            m_resolver = resolver;

            m_entityManager = m_resolver.Resolve<IEntityManager>();

            if(m_entityManager is null) {
                Debug.LogError($"{GetType().Name}でIEntityManagerを継承したクラスを取得できませんでした");
                return;
            }

            m_targetHolder = m_resolver.Resolve<ILockTargetHolder>();

            if(m_targetHolder is null) {
                Debug.LogError($"{GetType().Name}でILockTargetHolderを継承したクラスを取得できませんでした");
                return;
            }
        }

        public void NextTarget() {

        }

        protected void ObserveEntities() {

            m_entities
                .ObserveAdd()
                .Subscribe(x => {
                    OnEntitiesAdd(x);
                })
                .AddTo(this);

            m_entities
                .ObserveRemove()
                .Subscribe(x => {

                })
                .AddTo(this);
        }

        protected virtual void OnEntitiesAdd(CollectionAddEvent<GameObject> x) {

            if(m_targetHolder.GetTarget() is null && x.Value is not null) {
                m_targetHolder.SetTarget(x.Value);
            }
        }

        protected virtual void OnEntitiesRemove(CollectionRemoveEvent<GameObject> x) {
            if(m_targetHolder.GetTarget() == x.Value) {

            }
        }

    }
}
