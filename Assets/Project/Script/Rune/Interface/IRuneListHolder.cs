using System.Collections.Generic;

namespace Teiwas.Script.Rune.Interface {
    public interface IRuneListHolder {
        
        public RuneInstance GetRune (int index);
        
        public List<RuneInstance> GetRuneList ();

        public bool GetRuneListIsFull();
        
    }
}