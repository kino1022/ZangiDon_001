using System;
using DefaultNamespace;
using Project.Script.Rune;
using Sirenix.OdinInspector;
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
        [SerializeField] protected ARuneBase[] m_runes = Array.Empty<ARuneBase>();


        private void Awake() {
            SetUpStockRune();
        }
        
        //-----------------------API Methods--------------------------------

        public ARuneBase SelectRune(int index) {
            
            return m_runes[index];
        }
        
        //-----------------------setup methods------------------------------
        
        /// <summary>
        /// ストックルーンの初期化
        /// </summary>
        protected void SetUpStockRune() {
            m_runes = new ARuneBase[m_range];
            for (int i = 0; i < m_range - 1; i++) {
                m_runes[i] = m_supply.SupplyRune();
            }
        }
        
        //-------------------------hook point--------------------------------

        protected void OnSelectRune(int index) {
            
        }
    }
}