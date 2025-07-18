using System;
using Teiwas.Script.Interface;
using Teiwas.Script.Rune.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Rune.Manager.Interface;
using UnityEngine;

namespace Teiwas.Script.Rune.Manager {
    /// <summary>
    /// ルーン選択欄のコンポーネント
    /// </summary>
    public class RuneSelector : ARuneManager, IRuneSelector {
        
        [SerializeField, OdinSerialize, LabelText("ルーン供給元")]
        protected IRuneSupplier m_supplier;
        
        [Button("ルーン選択")]
        public void RuneSelected(int index) {

            if (m_runes[index] == null) {
                
            }

            if (index < 0 || index > m_amount) {
                Debug.LogError($"選択されたルーンのIndexが不正です、ルーン選択のコードを見直してください");
                return;
            }
            
            var rune = List[index];

            if (rune == null) {
                Debug.LogError("ルーンの入っていない選択欄が選択されました");
                return;
            } 
            
            m_sender.Send(rune);
            Remove(index);
        }

        [Button("ルーン補充")]
        protected void GetSupply() {
            //ルーンが満タンの際の終了処理
            if (m_isFull) {
                Debug.LogError($"ルーンが満タンな状態でルーンが補充されそうになりました");
                return;
            }
            
            Add(m_supplier.Supply());
        }
        
        [Button("デバック：全補充")]
        public void DEBUG_ALLSUPPLY() {
            for (int i = 0; i < m_amount; ++i) {
                if (List.ContainsKey(i) == false) {
                    GetSupply();
                }
            }
        }
    }
}