using ObservableCollections;
using Project.Script.UIControl.PlayerHUD.Rune.Interface;
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
            
            if (m_player == null) {
                Debug.Log("インスペクター上でITargetHolder<GameObject>がアタッチされていないため自動取得します");
                m_player = GetComponent<ITargetHolder<GameObject>>();

                if (m_player == null) {
                    Debug.Log("ITargetHolderが取得できなかったため、ペアレント全体から取得します");
                    m_player = GetComponentInParent<ITargetHolder<GameObject>>();

                    if (m_player == null) {
                        Debug.LogError("ITargetHolderがペアレント上にもなかったため処理を中断します");
                        return;
                    }
                    
                }
            }
            
            m_model = m_player.GetTarget().GetComponent<M>();

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
                .ObserveAdd()
                .Subscribe(x => {
                    Debug.Log($"要素が追加されたのを検知しました");
                    OnAdd(x);
                }).AddTo(this);
            
            //要素が除外されることに対する購読処理
            m_model.List
                .ObserveRemove()
                .Subscribe(x => {
                    Debug.Log("要素が除外された事を検知しました");
                    OnRemove(x);
                }).AddTo(this);
            
            //要素が移動されることに対する購読処理
            m_model.List
                .ObserveMove()
                .Subscribe(x => {
                    Debug.Log("リストの要素の移動を検知しました");
                    OnMove(x);
                }).AddTo(this);
            
            //要素がクリアされることに対する購読処理
            m_model.List
                .ObserveClear()
                .Subscribe(x => {
                    Debug.Log("リストがクリアされた事を検知しました");
                    OnClear();
                }).AddTo(this);
        }

        protected virtual void OnAdd(CollectionAddEvent<IRune> x) {
            m_view.Set(x.Index,x.Value);
        }

        protected virtual void OnRemove(CollectionRemoveEvent<IRune> x) {
            m_view.Set(x.Index,null);
        }

        protected virtual void OnMove(CollectionMoveEvent<IRune> x) {
            InitializeView();
        }

        protected virtual void OnClear() {
            InitializeView();
        }
    }
}