using System.Collections.Generic;
using Teiwas.Script.Rune.Interface;

namespace Teiwas.Script.UIControl.PlayerHUD.RuneSelector.Interface {
    public interface IRuneSelectorView {
        
        public void Set(int index,IRune rune);
        
        public void Remove(int index);
    }
}