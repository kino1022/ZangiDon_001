using System;
using DefaultNamespace;
using Project.Script.Rune;
using Sirenix.OdinInspector;
using UnityCommonModule.Target.Interface;
using UnityEngine;

namespace Project.Script.RuneManage {
    
    public class RuneSelector : SerializedMonoBehaviour {
        /// <summary>
        /// ルーンを補充する際の補充元
        /// </summary>
        [SerializeField] protected IRuneSupplier m_supply;
        
        /// <summary>
        /// ストックするルーンの最大数
        /// </summary>
        [SerializeField] protected int m_range = 6;
        
        /// <summary>
        /// ストックしているルーン
        /// </summary>
        [SerializeField] protected SelectorSlot[] m_slots = Array.Empty<SelectorSlot>();

        [SerializeField] protected float m_reSupply = 10.0f;


        private void Awake() {
            SetUpStockRune();
        }
        
        
        //-----------------------API Methods--------------------------------

        // public ARuneBase SelectRune(int index) {
        //     
        //     return m_slots.[index];
        // }

        public void DeleteRune(int index) {
            
        }

        public void DeleteRune(ARuneBase rune) {
            
        }
        
        //-----------------------setup methods------------------------------
        
        /// <summary>
        /// ストックルーンの初期化
        /// </summary>
        protected void SetUpStockRune() {
            m_slots = new SelectorSlot[m_range];
            for (int i = 0; i < m_range - 1; i++) {
                SetUpSlot(m_supply.SupplyRune(), i);
            }
        }

        protected void SetUpSlot(ARuneBase rune, int index) {
            m_slots[index] = new SelectorSlot(rune,m_reSupply);
        }
        
        //-------------------------hook point--------------------------------

        protected void OnSelectRune(int index) {
            
        }
    }
}