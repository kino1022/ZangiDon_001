using System.Collections.Generic;
using Project.Script.Rune.Interface;

namespace Project.Script.UIControl.PlayerHUD.RuneSelector.Interface {
    public interface IRuneSelectorView {
        
        public void Set(int index,IRune rune);
        
        public void Remove(int index);
    }
}