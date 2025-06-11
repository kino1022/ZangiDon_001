using Project.Script.Interface;

namespace Project.Script.Rune.Manager {
    public class MainRuneSlot : ARuneManager {
        
        public MainRuneSlot(int amount, IReceiver<RuneInstance> receiver, ISender<RuneInstance> sender) 
            : base(amount, receiver, sender) {
            
        }
        
    }
}