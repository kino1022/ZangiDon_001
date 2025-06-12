using Project.Script.Rune.Manager.Module;

namespace Project.Script.Rune.Manager.Factory {
    public class SubSlotFactory : ARuneManagerFactory<SubRuneSlot> {
        
        protected new int m_amount = 3;

        public override SubRuneSlot Create() {
            return new SubRuneSlot(m_amount, new RuneReceiverModule(), new DummySender());
        }

    }
}