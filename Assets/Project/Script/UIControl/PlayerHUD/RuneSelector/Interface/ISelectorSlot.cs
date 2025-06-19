using Project.Script.Rune.Interface;

namespace Project.Script.UIControl.PlayerHUD.RuneSelector.Interface {
    public interface ISelectorSlot {
        public IRune Rune { get;}
        
        public void Set(IRune rune);
        
        public void Remove();
    }
}