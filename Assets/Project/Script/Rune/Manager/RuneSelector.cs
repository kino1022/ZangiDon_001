using System;
using Project.Script.Interface;
using Project.Script.Rune.Manager.Interface;

namespace Project.Script.Rune.Manager {
    public class RuneSelector : ARuneManager , ISelectableRuneList {
        
        protected IRuneSupplier m_supplier;

        public Action<RuneInstance> SelectRuneEvent { get; set; }

        public RuneSelector(IRuneSupplier supplier,int amount, IReceiver<RuneInstance> receiver, ISender<RuneInstance> sender) 
            : base(amount, receiver, sender) {
            m_supplier = supplier;

            for (int i = 0; i < m_amount; i++) {
                m_rune.Add(supplier.SupplyRune());
            }
        }

        public void SelectRune(int index) {
            throw new System.NotImplementedException();
        }
    }
}