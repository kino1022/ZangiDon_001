using System;
using System.Collections.Generic;
using Project.Script.Interface;
using Project.Script.Rune.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using VContainer;

namespace Project.Script.Rune.Manager {
    [Serializable]
    public class ARuneManager : IRuneListHolder {

        public IReceiver<RuneInstance> Receiver => m_receiver;
        
        public ISender<RuneInstance> Sender => m_sender;
        
        [OdinSerialize, LabelText("管理しているルーン")]
        protected List<RuneInstance> m_rune = new List<RuneInstance>();

        [OdinSerialize, LabelText("管理できるルーンの数")]
        protected int m_amount;
        
        protected IReceiver<RuneInstance> m_receiver;

        protected ISender<RuneInstance> m_sender;
        
        public ARuneManager(int amount, IReceiver<RuneInstance> receiver, ISender<RuneInstance> sender) {
            m_amount = amount;
            m_receiver = receiver;
            m_sender = sender;
        }

        public RuneInstance GetRune(int index) {
            return m_rune[index];
        }

        public List<RuneInstance> GetRunes() {
            return m_rune;
        }

        public bool GetRuneListIsFull () {
            return m_rune.Count < m_amount;
        }

        public void AddRune(RuneInstance rune) {
            m_rune.Add(rune);
        }

        public void RemoveRune(RuneInstance rune) {
            m_rune.Remove(rune);
        }
    }
}