using System;
using Project.Script.Interface;
using Project.Script.Rune.Interface;
using Project.Script.Rune.Manager.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Rune.Manager {
    [Serializable]
    public class SelectedRuneReceiver : ISender<IRune> {

        [SerializeField, OdinSerialize, LabelText("メインのルーンスロット")]
        protected IRuneListManager m_main;

        [SerializeField, OdinSerialize, LabelText("サブのルーンスロット")]
        protected IRuneListManager m_sub;
        
        public void Send(IRune rune) {
            if (!m_main.IsFull) {
                m_main.Add(rune);
            } 
            else if (!m_sub.IsFull) {
                m_sub.Add(rune);
            }
            else {
                Debug.LogError("ルーンのスロットが満タンな状態でルーンが送信されました");
                return;
            }
        }
    }
}