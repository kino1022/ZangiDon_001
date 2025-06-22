using Teiwas.Script.Rune.Interface;

namespace Project.Script.UIControl.PlayerHUD.Rune.Interface {
    public interface IRuneListView {
        
        public void Set(int index, IRune rune);
        
        public void Remove(int index);
        
    }
}