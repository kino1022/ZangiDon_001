using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using ObservableCollections;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Interface;
using Teiwas.Script.Rune.Interface;
using Teiwas.Script.Rune.Manager.Interface;
using UnityEngine;
using VContainer;

namespace Teiwas.Script.Rune.Manager {
    /// <summary>
    /// ルーンを管理するクラスの基底クラス
    /// </summary>
    [Serializable]
    public abstract class ARuneManager : SerializedMonoBehaviour, IRuneListManager {

        [SerializeField, OdinSerialize, LabelText("管理しているルーン")] [CanBeNull]
        protected ObservableDictionary<int, IRune?> m_runes;

        [SerializeField, LabelText("管理できるルーンの数"), ProgressBar(0, 24)]
        protected  int m_amount = 0;
        

        [OdinSerialize, LabelText("ルーン送信モジュール")]
        protected ISender<IRune> m_sender;

        protected bool m_isFull = false;

        public IReadOnlyObservableDictionary<int, IRune?> List => m_runes;

        public bool IsFull => m_isFull;
        
#nullable enable
        private void Awake() {
            m_runes = new ObservableDictionary<int, IRune?>();
            Initialize();
        }
#nullable disable

        [Button("ルーン追加")]
        public void Add(IRune rune) { 
            var index = GetFirstEmpty();

            if (index < 0 || index >= m_amount) {
                Debug.LogError("ルーンが満タンの状態でルーンが追加されました");
                return;
            }
                
            m_runes.Add(index, rune);
        }

        [Button("ルーン除外")]
        public void Remove(IRune rune) {
            var targets = m_runes
                .Where(pair => EqualityComparer<IRune>.Default.Equals(pair.Value, rune))
                .Select(pair => pair.Value)
                .ToList();

            if (targets.Count == 0) {
                Debug.LogError("除外対象に指定されたルーンが存在しませんでした");
                return;
            }

            targets.Remove(targets.FirstOrDefault());
        }

        [Button("ルーン除外(index)")]
        public void Remove(int index) {
            m_runes.Remove(index);
        }

        protected void Initialize() { OnInitialize(); }

        protected virtual void OnInitialize() {
            
            RegisterObserveRuneList();
        }

        protected void RegisterObserveRuneList() {
            
            m_runes
                .ObserveDictionaryAdd()
                .Subscribe(x => {
                    OnAddRune(x);
                }).AddTo(this);

            m_runes
                .ObserveDictionaryRemove()
                .Subscribe(x => {
                    OnRemoveRune(x);
                }).AddTo(this);
            
            m_runes
                .ObserveDictionaryReplace()
                .Subscribe(x => {
                    OnReplaceRune(x);
                }).AddTo(this);
        }

        protected void RegisterObserveRune(IRune rune) {
            Observable
                .EveryValueChanged(rune, x => x.GetIsActive() == false)
                .Subscribe(x => {
                    OnRuneDisActive(rune);
                });
        }

#nullable enable
        protected virtual void OnAddRune(DictionaryAddEvent<int,IRune?> x) {

            //追加ルーンでルーンが満タンになった際の処理
            if (m_runes.Count == m_amount) {
                Debug.Log("ルーンのリストが満タンになったのでIsFullのフラグを立てます");
                m_isFull = true;
            }

            //ルーンが最大数を超えて追加された際の処理
            if (m_runes.Count > m_amount) {
                Debug.LogError("ルーンの管理限界を超えてルーンが追加されたためルーンを除外し、処理を強制中断します");
                m_runes.Remove(x.Key);
                return;
            }

        }

        protected virtual void OnRemoveRune(DictionaryRemoveEvent<int,IRune?> x) {

            //最大数を下回った際の処理
            if (m_runes.Count < m_amount && m_isFull) {
                Debug.Log("管理しているルーンの数が最大数を下回ったためIsFullをfalseにします");
                m_isFull = false;
            }
        }

        protected virtual void OnReplaceRune(DictionaryReplaceEvent<int, IRune?> x) {
            
        }
        
#nullable disable

        protected void OnRuneDisActive(IRune rune) { }

        protected int GetFirstEmpty() {
            for (int i = 0; i < m_amount; ++i) {
                if (!m_runes.ContainsKey(i)) {
                    return i;
                }
            }
            
            return -1;
        }
    }
}