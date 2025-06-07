using System;
using Project.Script.Interface;
using Project.Script.Rune.Effect.Interface;
using UnityCommonModule.Target.Interface;

namespace Project.Script.Rune.Manage.RuneSelector.Module {
    [Serializable]
    public class SendTargetSelector : ITargetHolder<IReceiver<RuneInstance>> {

        protected ARuneManager m_mainSlot;
        
        protected ARuneManager m_supportSlot;

        public SendTargetSelector(ARuneManager mainSlot, ARuneManager supportSlot) {
            
        }

        public IReceiver<RuneInstance> GetTarget() {
            
            if (m_mainSlot.List.GetIsFullList()) {
                return m_mainSlot.Receiver;
            }
            else if (m_supportSlot.List.GetIsFullList()) {
                return m_supportSlot.Receiver;
            }
            else {
                return null;
            }
        }
    }
}