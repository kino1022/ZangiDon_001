using System;
using System.Linq;
using ObservableCollections;
using R3;
using Teiwas.Script.Rune.Interface;
using Teiwas.Script.Rune.Manager.Interface;
using Teiwas.Script.UIControl.PlayerHUD.RuneSelector.Interface;
using UnityEngine;

namespace Teiwas.Script.UIControl.PlayerHUD.RuneSelector {
    /// <summary>
    /// IRuneSelectorとIRuneSelectorViewの仲介をするクラス
    /// </summary>
    [Serializable]
    public class RuneSelectorPresenter {

        protected IRuneSelector m_model;
        
        protected IRuneSelectorView m_view;

        public RuneSelectorPresenter(GameObject character, IRuneSelectorView view) {
            m_model = character.GetComponent<IRuneSelector>();

            if (m_model == null) {
                Debug.LogError("取得されたGameObjectにRuneSelectorのインスタンスが存在しませんでした");
                return;
            }
            
            m_view = view;

            InitializeView();
            
            RegisterObserver();
        }

        protected virtual void InitializeView() {
            Debug.Log("RuneSelectorViewの初期化を開始します");
            
            var list = m_model.List.ToList();

            for (int i = 0; i < list.Count; ++i) {
                if (list[i] == null) {
                    m_view.Remove(i);
                }
                m_view.Set(i, list[i]);
            }
        }
        
        
        /// <summary>
        /// IRuneSelector.Listの監視を開始するメソッド
        /// </summary>
        protected void RegisterObserver() {
            
            //要素の追加の監視
            m_model.List
                .ObserveAdd()
                .Subscribe(x => {
                    Debug.Log("RuneSelectorでの要素追加を検知しました");
                    OnModelAdd(x);
                });
            
            //要素の除外の監視
            m_model.List
                .ObserveRemove()
                .Subscribe(x => {
                    Debug.Log("RuneSelectorでの要素除外を検知しました");
                    OnModelRemove(x);
                });
            
            //要素の移動の検知
            m_model.List
                .ObserveMove()
                .Subscribe(x => {
                    Debug.Log("RuneSelectorでの要素の移動を検知しました");
                    OnModelMove(x);
                });
            
            //要素のクリアの検知
            m_model.List
                .ObserveClear()
                .Subscribe(x => {
                    Debug.Log("RuneSelectorでのリストのクリアを検知しました");
                    OnModelClear();
                });
        }

        protected void OnModelAdd(CollectionAddEvent<IRune> x) {
            m_view.Set(x.Index, x.Value);
        }

        protected void OnModelRemove(CollectionRemoveEvent<IRune> x) {
            m_view.Remove(x.Index);
        }

        protected void OnModelMove(CollectionMoveEvent<IRune> x) {
            InitializeView();
        }

        protected void OnModelClear() {
            InitializeView();
        }
    }
}