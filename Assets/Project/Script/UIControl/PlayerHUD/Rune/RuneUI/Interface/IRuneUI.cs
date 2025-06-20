using Project.Script.UIControl.PlayerHUD.Rune.Definition;
using Teiwas.Script.Rune.Interface;

namespace Project.Script.UIControl.PlayerHUD.Rune.RuneUI.Interface {
    public interface IRuneUI {
        
        public RunePosition Position { get;}

        public void Set(IRune rune);

        public void Remove();
    }
}