using System;
using System.Collections.Generic;
using System.Linq;
using ObservableCollections;
using Project.Script.Interface;
using Project.Script.Rune.Interface;
using Project.Script.Rune.Manager.Interface;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using VContainer;

namespace Project.Script.Rune.Manager {
    /// <summary>
    /// ルーンを管理するクラスの基底クラス
    /// </summary>
    [Serializable]
    public abstract class ARuneManager : SerializedMonoBehaviour, IRuneListManager {

        [SerializeField, OdinSerialize, LabelText("管理しているルーン")]
        protected ObservableList<IRune> m_runes = new ObservableList<IRune>();

        [SerializeField, LabelText("管理できるルーンの数"), ProgressBar(0, 24)]
        protected int m_amount = 0;
        

        [OdinSerialize, LabelText("ルーン送信モジュール")]
        protected ISender<IRune> m_sender;

        protected bool m_isFull = false;

        public IReadOnlyObservableList<IRune> List => m_runes;

        public bool IsFull => m_isFull;

        private void Awake() { Initialize(); }

        public void Add(IRune rune) { m_runes.Add(rune); }

        public void Remove(IRune rune) { m_runes.Remove(rune); }

        protected void Initialize() { OnInitialize(); }

        protected virtual void OnInitialize() { RegisterObserveRuneList(); }

        protected void RegisterObserveRuneList() {

            m_runes.ObserveAdd().Subscribe(x => { OnAddRune(x); });

            m_runes.ObserveRemove().Subscribe(x => { OnRemoveRune(x); });
        }

        protected void RegisterObserveRune(IRune rune) {
            Observable
                .EveryValueChanged(rune, x => x.GetIsActive() == false)
                .Subscribe(x => {
                    OnRuneDisActive(rune);
                });
        }

        protected virtual void OnAddRune(CollectionAddEvent<IRune> x) {

            //追加ルーンでルーンが満タンになった際の処理
            if (m_runes.Count == m_amount) {
                Debug.Log("ルーンのリストが満タンになったのでIsFullのフラグを立てます");
                m_isFull = true;
            }

            //ルーンが最大数を超えて追加された際の処理
            if (m_runes.Count > m_amount) {
                Debug.LogError("ルーンの管理限界を超えてルーンが追加されたためルーンを除外し、処理を強制中断します");
                m_runes.Remove(x.Value);
                return;
            }

        }

        protected virtual void OnRemoveRune(CollectionRemoveEvent<IRune> x) {

            //最大数を下回った際の処理
            if (m_runes.Count < m_amount && m_isFull) {
                Debug.Log("管理しているルーンの数が最大数を下回ったためIsFullをfalseにします");
                m_isFull = false;
            }
        }

        protected void OnRuneDisActive(IRune rune) { }
    }
}