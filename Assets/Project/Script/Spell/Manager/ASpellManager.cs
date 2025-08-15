using System;
using ObservableCollections;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Spell.Manager.Interface;
using Teiwas.Script.Spell.Manager.Module;
using Teiwas.Script.Spell.Manager.Module.Interface;
using Teiwas.Script.Spell.Slot.Interface;
using UnityEngine;
using VContainer;

namespace Teiwas.Script.Spell.Manager {
    public abstract class ASpellManager<S> : SerializedMonoBehaviour, ISpellManager<S> where S : ISpellSlot , new() {

        [TitleGroup("ランタイム")]
        [OdinSerialize, LabelText("スペルリスト")]
        protected ObservableDictionary<int,S> m_spells = new ();

        [TitleGroup("設定")] [SerializeField, LabelText("リストの長さ"), ProgressBar(0, 10)]
        protected int m_length = 6;

        [TitleGroup("参照")] [OdinSerialize, LabelText("リストフル監視")]
        protected IFullSpellManager m_isFull;

        protected IObjectResolver m_resolver;

        public int Length => m_length;

        public IReadOnlyObservableDictionary<int,S> Spells => m_spells;

        public bool IsFull => m_isFull.IsFull;

        [Inject]
        public virtual void Construct(IObjectResolver resolver) {

            m_resolver = resolver
                        ?? throw new ArgumentNullException($"{GetType().Name}でのIObjectResolverの取得に失敗しました");
        }

        protected virtual void Awake() {
            //スペル数監視クラスのインスタンス
            m_isFull = new FullSpellManager<S>(this);

            InitializeDictionary();
        }

        /// スペルリストの初期化処理
        protected virtual void InitializeDictionary() {
            m_spells = new ObservableDictionary<int,S>();

            m_spells.Clear();

            for(int i = 0; i < m_length; i++) {
                m_spells.Add(i, new S());
            }
        }
        
    }
}
