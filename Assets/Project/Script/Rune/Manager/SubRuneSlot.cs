using Project.Script.Interface;

namespace Project.Script.Rune.Manager {
    public class SubRuneSlot : ARuneManager {
        public SubRuneSlot(int amount, IReceiver<RuneInstance> receiver, ISender<RuneInstance> sender) 
            : base(amount, receiver, sender) {
            
        }
        
        
    }
}