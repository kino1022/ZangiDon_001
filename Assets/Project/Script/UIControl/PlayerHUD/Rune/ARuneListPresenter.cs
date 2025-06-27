using ObservableCollections;
using Project.Script.UIControl.PlayerHUD.Rune.Interface;
using Project.Script.Utility;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Rune.Interface;
using Teiwas.Script.Rune.Manager.Interface;
using UnityCommonModule.Target.Interface;
using UnityEngine;

namespace Project.Script.UIControl.PlayerHUD.Rune {
    public abstract class ARuneListPresenter<M,V> : SerializedMonoBehaviour, IRuneListPresenter 
        where M : IRuneListManager  where V : IRuneListView {
        
        [OdinSerialize, LabelText("Model Class")]
        protected M m_model;
        
        [OdinSerialize, LabelText("View Class")]
        protected V m_view;

        protected ITargetHolder<GameObject> m_player;

        private void Start() {
            
            m_player = ComponentsUtility.GetComponentFromWhole<ITargetHolder<GameObject>>(this.gameObject);

            if (m_player == null) {
                Debug.LogError("プレイヤーのオブジェクト取得コンポーネントを取得できませんでした。処理を中断します");
                return;
            }
            
            m_model = ComponentsUtility.GetComponentFromWhole<M>(m_player.GetTarget());

            if (m_model == null) {
                Debug.LogError($"取得したオブジェクトに{typeof(M)}を継承したオブジェクトが存在しませんでした。処理を中断します");
                return;
            }

            InitializeView();
            
            RegisterObserver();
        }
        
        protected abstract void InitializeView();

        protected void RegisterObserver() {
            
            Debug.Log($"{m_model.GetType()}のリスト変化購読処理を開始します");
            
            //要素が追加されることに対する購読処理
            m_model.List
                .ObserveDictionaryAdd()
                .Subscribe(x => {
                    Debug.Log($"要素が追加されたのを検知しました");
                    OnAdd(x);
                }).AddTo(this);
            
            //要素が除外されることに対する購読処理
            m_model.List
                .ObserveDictionaryRemove()
                .Subscribe(x => {
                    Debug.Log("要素が除外された事を検知しました");
                    OnRemove(x);
                }).AddTo(this);
            
            
            //要素がクリアされることに対する購読処理
            m_model.List
                .ObserveDictionaryReplace()
                .Subscribe(x => {
                    Debug.Log("リストがクリアされた事を検知しました");
                    OnReplace(x);
                }).AddTo(this);
        }
        
        #nullable enable
        protected virtual void OnAdd(DictionaryAddEvent<int,IRune?> x) {
           InitializeView();
        }

        protected virtual void OnRemove(DictionaryRemoveEvent<int,IRune?> x) {
            InitializeView();
        }

        protected virtual void OnReplace(DictionaryReplaceEvent<int, IRune?> x) {
            InitializeView();
        }
        #nullable disable
    }
}