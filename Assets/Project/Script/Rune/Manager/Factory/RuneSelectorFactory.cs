using System;
using Project.Script.Interface;
using Project.Script.Rune.Manager.Interface;
using Project.Script.Rune.Manager.Module;
using Sirenix.Serialization;
using UnityCommonModule.Target.Interface;

namespace Project.Script.Rune.Manager.Factory {
    [Serializable]
    public class RuneSelectorFactory : ARuneManagerFactory<RuneSelector> {
        
        protected new int m_amount = 6;
        
        protected ITargetHolder<ARuneManager> m_targetHolder;
        
        protected ISender<RuneInstance> m_sender;
        
        protected IRuneSupplier m_supplier;

        public RuneSelectorFactory(IRuneSupplier supplier,ARuneManager main, ARuneManager sub) {
            m_supplier = supplier;
            m_targetHolder = new TargetSelectorModule(main, sub);
            m_sender = new SelectorSenderModule(m_targetHolder);
        }

        public override RuneSelector Create() {
            return new RuneSelector(m_supplier,m_amount, new RuneReceiverModule() ,m_sender);
        }
    }
}