using System;
using System.Linq;
using ObservableCollections;
using Project.Script.UIControl.PlayerHUD.Rune.Interface;
using Project.Script.Utility;
using R3;
using Teiwas.Script.Rune.Interface;
using Teiwas.Script.Rune.Manager.Interface;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Script.UIControl.PlayerHUD.Rune {
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="M">Modelに該当するクラス</typeparam>
    /// <typeparam name="V">Viewに該当するクラス</typeparam>
    public abstract class ARuneListPresenter<M,V> : IRuneListPresenter , IDisposable , IInitializable
        where M : IRuneListManager  where V : IRuneListView {

        protected M m_model;

        protected V m_view;

        protected CompositeDisposable m_disposable = new CompositeDisposable();

        [Inject]
        protected ARuneListPresenter(M model, V view) {
            Debug.Log($"{this.GetType().Name}のコンストラクタが読み込まれました");

            m_model = model;
            m_view = view;

            RegisterObserver();
            InitializeView();
        }

        public void Initialize() {

        }

        public void Dispose() {
            m_disposable.Dispose();
        }

        protected virtual void InitializeView() {

            Debug.Log("表示の初期化を開始します");

            for (int i = 0; i < m_model.Amount; i++) {

                if (m_model.List.ContainsKey(i) == false) {
                    Debug.Log("要素が存在しなかったため、UIから除外します");
                    m_view.Remove(i);
                }
                else {
                    if (m_model.List.Any(pair => pair.Key == i && m_model.List.TryGetValue(i, out IRune rune))) {
                        Debug.Log("要素が取得できたため、UIに対して追加します");
                        m_model.List.TryGetValue(i, out IRune rune);
                        if (rune?.RuneSprite == null) {
                            Debug.LogError($"{this.GetType().Name}の処理内で{rune.GetType().Name}にスプライトが確認できませんでした");
                        }
                        m_view.Set(i,rune);
                    }
                    else {
                        Debug.Log("キーのみが取得できたため、UIから除外します");
                        m_view.Remove(i);
                    }
                }
            }
        }

        protected void RegisterObserver() {

            Debug.Log($"{GetType()}のリスト購読処理を開始します");

            m_model
                .List
                .ObserveDictionaryAdd()
                .Subscribe(x => {
                    Debug.Log($"{m_model.GetType().Name}におけるリスト内容の追加を検知しました");
                    OnAdd(x);
                })
                .AddTo(m_disposable);

            m_model
                .List
                .ObserveDictionaryRemove()
                .Subscribe(x => {
                    Debug.Log($"{m_model.GetType().Name}におけるリスト内容の除外を検知しました");
                    OnRemove(x);
                })
                .AddTo(m_disposable);

            m_model
                .List
                .ObserveDictionaryReplace()
                .Subscribe(x => {
                    Debug.Log($"{m_model.GetType().Name}におけるリスト順の変化を検知しました");
                    OnReplace(x);
                })
                .AddTo(m_disposable);
        }


        protected virtual void OnAdd(DictionaryAddEvent<int,IRune> x) {
            InitializeView();
        }

        protected virtual void OnRemove(DictionaryRemoveEvent<int,IRune> x) {
            InitializeView();
        }

        protected virtual void OnReplace(DictionaryReplaceEvent<int,IRune> x) {
            InitializeView();
        }
    }
}
