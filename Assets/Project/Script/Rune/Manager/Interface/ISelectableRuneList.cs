using System;
using Project.Script.Rune.Interface;

namespace Project.Script.Rune.Manager.Interface {
    public interface ISelectableRuneList : IRuneListHolder {
        
        public void SelectRune(int index);
        
        public Action<RuneInstance> SelectRuneEvent { get; set; }
    }
}