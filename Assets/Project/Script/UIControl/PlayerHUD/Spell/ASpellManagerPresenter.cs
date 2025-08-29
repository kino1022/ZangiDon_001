using System;
using System.Collections.Generic;
using ObservableCollections;
using R3;
using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Manager.Interface;
using Teiwas.Script.Spell.Slot.Interface;
using Teiwas.Script.UIControl.PlayerHUD.Spell.Interface;
using Teiwas.Script.UIControl.PlayerHUD.Spell.Slot;
using Teiwas.Script.UIControl.PlayerHUD.Spell.Slot.Factory.Interface;
using UnityEngine;
using VContainer;

namespace Project.Script.UIControl.PlayerHUD.Spell {
    /// <summary>
    /// SpellManagerのMVPパターンにおけるPresenterの役割を持つクラスの基底クラス
    /// </summary>
    /// <typeparam name="View"></typeparam>
    /// <typeparam name="Manager"></typeparam>
    /// <typeparam name="Slot"></typeparam>
    /// <typeparam name="Instance"></typeparam>
    /// <typeparam name="SlotPresenter"></typeparam>
    public abstract class ASpellManagerPresenter<View,Manager,Slot,Instance,SlotPresenter> : ISpellManagerPresenter
        where View : ISpellManagerView<Slot,Instance>
        where Manager : ISpellManager<Slot,Instance> 
        where Slot : ISpellSlot<Instance> 
        where Instance : ISpellInstance 
        where SlotPresenter : ISpellSlotPresenter<Slot, Instance>
    {

        protected Manager m_model;
        
        protected View m_view;
        
        protected CompositeDisposable m_disposable;
        
        protected readonly IObjectResolver m_resolver;
        
        protected Dictionary<int, SlotPresenter> m_spells;
        
        protected ISpellSlotPresenterFactory<SlotPresenter,Slot,Instance,ISpellSlotUIView> m_presenterFactory;

        [Inject]
        protected ASpellManagerPresenter(IObjectResolver resolver) {
            m_resolver = resolver ?? throw new ArgumentNullException();
        }

        public virtual void Start() {
            
            m_model = m_resolver.Resolve<Manager>() 
                      ?? throw new ArgumentNullException();
            
            m_view = m_resolver.Resolve<View>() 
                     ?? throw new ArgumentNullException();

            m_presenterFactory = m_resolver.Resolve<ISpellSlotPresenterFactory<SlotPresenter, Slot, Instance, ISpellSlotUIView>>() 
                                 ?? throw new ArgumentNullException();
            
            InitializeDisposable();
            
            InitializeSlotPresenter();
            
            RegisterObserve();
        }

        public virtual void Dispose() {
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        protected virtual void RegisterObserve() {

            if (m_disposable is null) {
                m_disposable = new CompositeDisposable();
            }
            
            m_model.Spells
                .ObserveChanged()
                .Subscribe(x => OnChangeSpells())
                .AddTo(m_disposable);
        }

        protected virtual void InitializeDisposable() {
            
            if (m_disposable != null) m_disposable.Dispose();
            
            m_disposable = new CompositeDisposable();
        }


        /// <summary>
        /// SlotPresenterの生成と初期化を行うクラスに対して約束するインターフェース
        /// 実行の前提としてViewクラスのスロットが指定個数あることが条件になる
        /// </summary>
        protected virtual void InitializeSlotPresenter() {
            
            //Viewのスロット数とManagerのスロット数の齟齬がないかの検知処理
            if (m_model.Length == m_view.Spells.Count) {
                
                //view側の辞書にnullがないかの検知処理(以降はis not nullであることを保証)
                foreach (var spell in m_view.Spells) {
                    if (spell.Value is null) {
                        throw new NullReferenceException($"{nameof(m_view)}の辞書にnullが存在しました");
                    }
                }
                
            }
            else {
                
                if (m_model.Length < m_view.Spells.Count) {
                    Debug.LogError($"実際のスロット数よりも{nameof(m_view)}のスロット数の方が大きいです");
                }

                if (m_model.Length > m_view.Spells.Count) {
                    Debug.LogError($"実際のスロット数よりも{nameof(m_view)}のスロット数の方が少ないです");
                }
                
                throw new TypeInitializationException(
                    $"SpellManagerのUI要素が不正であったためUIの初期化に失敗しました",
                    new ArgumentOutOfRangeException()
                    );
            }
            
            m_spells = new Dictionary<int, SlotPresenter>();

            for (int i = 0; i < m_model.Length; ++i) {
                var ele = new KeyValuePair<int, SlotPresenter>(i,m_presenterFactory.Create(m_model.Spells[i],m_view.Spells[i]));
                m_spells.Add(ele.Key, ele.Value);
            }
        }

        protected virtual void OnChangeSpells() {
            
        }
    }
}