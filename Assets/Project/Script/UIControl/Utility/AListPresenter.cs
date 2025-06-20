using ObservableCollections;
using R3;
using UnityCommonModule.Target.Interface;
using UnityEngine;

namespace Teiwas.Script.UIControl.Utility {
    public abstract class AListPresenter<T,M,V>{
        
        protected M m_model;

        protected V m_view;

        protected AListPresenter(ITargetHolder<GameObject> character, V view) {
            m_model = character.GetTarget().GetComponent<M>();

            if (m_model == null) {
                Debug.LogError($"{character.GetTarget().name}に{typeof(M).ToString()}を継承したコンポーネントがありませんんでした");
                return;
            }
            
            m_view = view;
            
            InitializeView();
        }

        protected abstract void InitializeView();
        
        /// <summary>
        /// R3によるリスト状態の監視を登録するメソッド
        /// </summary>
        /// <param name="list"></param>
        protected virtual void RegisterObserve(IReadOnlyObservableList<T> list) {
            
            list
                .ObserveAdd()
                .Subscribe(x => {
                    OnAdd(x);
                });

            list
                .ObserveRemove()
                .Subscribe(x => {
                    OnRemove(x);
                });

            list
                .ObserveClear()
                .Subscribe(x => {
                    OnClear();
                });

            list
                .ObserveMove()
                .Subscribe(x => {
                    OnMove(x);
                });
        }

        protected abstract void OnAdd(CollectionAddEvent<T> list);

        protected abstract void OnRemove(CollectionRemoveEvent<T> list);

        protected abstract void OnMove(CollectionMoveEvent<T> list);

        protected abstract void OnClear();
    }
}