using UnityCommonModule.Target.Interface;

namespace Project.Script.Rune.Manager.Module {
    
    public class TargetSelectorModule : ITargetHolder<ARuneManager> {

        protected ARuneManager m_main;

        protected ARuneManager m_sub;

        public TargetSelectorModule(ARuneManager main, ARuneManager sub) {
            m_main = main;
            m_sub = sub;
        }
        
        public ARuneManager GetTarget() {
            return m_main;
        }
    }
}