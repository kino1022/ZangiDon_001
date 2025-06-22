using Teiwas.Script.Rune.Interface;

namespace Teiwas.Script.UIControl.PlayerHUD.RuneSelector.Interface {
    public interface ISelectorSlot {
        public IRune Rune { get;}
        
        public void Set(IRune rune);
        
        public void Remove();
    }
}