using Project.Script.Interface;
using UnityCommonModule.Target.Interface;

namespace Project.Script.Rune.Manager.Module {
    
    public class SelectorSenderModule : ISender<RuneInstance> {
        
        protected ITargetHolder<ARuneManager> m_receiver;

        public SelectorSenderModule(ITargetHolder<ARuneManager> receiver) {
            m_receiver = receiver;
        }

        public void Send(RuneInstance rune) {
            m_receiver.GetTarget().Receiver.Receive(rune);
        }
    }
    
}