
using System;
using ObservableCollections;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Manager.Interface;
using Teiwas.Script.Spell.Manager.Module.Interface;
using Teiwas.Script.Spell.Slot.Factory.Interface;
using Teiwas.Script.Spell.Slot.Interface;
using UnityEngine;
using VContainer;

namespace Teiwas.Script.Spell.Manager {
    public abstract class ASpellManager<Slot, Instance> : SerializedMonoBehaviour, ISpellManager<Slot, Instance> where Slot : ISpellSlot<Instance> where Instance : ISpellInstance {
        
        protected ObservableDictionary<int, Slot> m_spells = new ObservableDictionary<int, Slot>();

        public IReadOnlyObservableDictionary<int, Slot> Spells => m_spells;
        
        [TitleGroup("設定")]
        [SerializeField, LabelText("管理できる量"), ProgressBar(0,20)]
        protected int m_length = 0;

        [TitleGroup("参照")] [OdinSerialize, LabelText("スペルフル監視クラス")]
        protected IManagerFillObserver m_fillObserver;
        
        public int Length => m_length;

        public bool IsFull => m_fillObserver.IsFull;

        protected IObjectResolver m_resolver;
        
        protected ISpellSlotFactory<Slot, Instance> m_slotFactory;
        
        [Inject]
        public void Construct(IObjectResolver resolver) {
            m_resolver = resolver ?? throw new ArgumentNullException();
        }

        protected virtual void Awake() {
            InitializeDictionary();
        }

        protected virtual void Start() {
            m_slotFactory = m_resolver.Resolve<ISpellSlotFactory<Slot, Instance>>()
                ?? throw new ArgumentNullException();
        }
        
        /// <summary>
        /// スペルリストの初期化を行う
        /// </summary>
        /// <exception cref="ArgumentNullException">生成されたISpellSlotがnullなら発火</exception>
        protected virtual void InitializeDictionary() {
            
            m_spells = new ObservableDictionary<int, Slot>();

            for (int i = 0; i < m_length; ++i) {
                
                var slot = m_slotFactory.Create();

                if (slot is null) {
                    throw new ArgumentNullException();
                }
                
                m_spells.Add(i, slot);
            }
        }
        
    }
}
