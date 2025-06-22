using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Interface;
using Teiwas.Script.Rune.Interface;
using Teiwas.Script.Rune.Manager.Interface;
using UnityEngine;

namespace Teiwas.Script.Rune.Manager {
    [Serializable]
    public class SelectedRuneReceiver : ISender<IRune> {

        [SerializeField, OdinSerialize, LabelText("メインのルーンスロット")]
        protected IRuneListManager m_main;

        [SerializeField, OdinSerialize, LabelText("サブのルーンスロット")]
        protected IRuneListManager m_sub;
        
        public void Send(IRune rune) {
            if (!m_main.IsFull) {
                m_main.Add(rune);
                return;
            } 
            else if (!m_sub.IsFull) {
                m_sub.Add(rune);
                return;
            }
            else {
                Debug.LogError("ルーンのスロットが満タンな状態でルーンが送信されました");
                return;
            }
        }
    }
}