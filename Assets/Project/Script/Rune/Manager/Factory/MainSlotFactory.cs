using System;
using Project.Script.Rune.Manager.Module;

namespace Project.Script.Rune.Manager.Factory {
    [Serializable]
    public class MainSlotFactory : ARuneManagerFactory<MainRuneSlot> {
        protected new int m_amount = 1;
        public override MainRuneSlot Create() {
            return new MainRuneSlot(m_amount, new RuneReceiverModule(), new DummySender());
        }
    }
}