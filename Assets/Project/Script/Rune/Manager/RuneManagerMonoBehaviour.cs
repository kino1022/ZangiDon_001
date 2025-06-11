using Project.Script.Rune.Interface;
using Project.Script.Rune.Manager.Factory;
using Project.Script.Rune.Manager.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Project.Script.Rune.Manager {
    public class RuneManagerMonoBehaviour : SerializedMonoBehaviour {

        public ISelectableRuneList Selector => m_selector;
        
        public IRuneListHolder Main => m_main;
        
        public IRuneListHolder Sub => m_sub;
        
        [OdinSerialize, LabelText("ルーンを供給するクラス")]
        protected IRuneSupplier m_supplier;
        
        [OdinSerialize, LabelText("選択可能なルーン")]
        protected RuneSelector m_selector;
        
        [OdinSerialize, LabelText("一文字目のルーン")]
        protected ARuneManager m_main;
        
        [OdinSerialize, LabelText("二文字目以降のルーン")]
        protected ARuneManager m_sub;
        
        [OdinSerialize, BoxGroup("Factory")]
        protected RuneSelectorFactory m_selectorFactory;
        
        [OdinSerialize, BoxGroup("Factory")]
        protected ARuneManagerFactory<MainRuneSlot> m_mainFactory;
        
        [OdinSerialize, BoxGroup("Factory")]
        protected ARuneManagerFactory<SubRuneSlot> m_subFactory;

        private void Awake() {
            
            m_mainFactory = new MainSlotFactory();
            m_main = m_mainFactory.Create();
            
            m_subFactory = new SubSlotFactory();
            m_sub = m_subFactory.Create();
            
            m_selectorFactory = new RuneSelectorFactory(m_supplier,m_main, m_sub);
            m_selector = m_selectorFactory.Create();
            
        }
    }
}