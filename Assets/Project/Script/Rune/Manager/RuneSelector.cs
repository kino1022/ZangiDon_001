using System;
using Project.Script.Interface;
using Project.Script.Rune.Interface;
using Project.Script.Rune.Manager.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Rune.Manager {
    /// <summary>
    /// ルーン選択欄のコンポーネント
    /// </summary>
    public class RuneSelector : ARuneManager, IRuneSelector {
        
        [SerializeField, OdinSerialize, LabelText("ルーン供給元")]
        protected IRuneSupplier m_supplier;
        
        public void RuneSelected(int index) {

            if (index < 0 || index > m_amount - 1) {
                Debug.LogError($"選択されたルーンのIndexが不正です、ルーン選択のコードを見直してください");
                return;
            }
            
            var rune = List[index];

            if (rune == null) {
                Debug.LogError("ルーンの入っていない選択欄が選択されました");
                return;
            } 
            
            m_sender.Send(rune);
        }

        protected override void OnReceiveRune(IRune rune) {
            Debug.Log("ルーンを受信したのでリストに追加します");
            Add(rune);
        }
        
    }
}