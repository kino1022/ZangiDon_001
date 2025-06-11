using System;
using Project.Script.Interface;

namespace Project.Script.Rune.Manager.Module {
    public class RuneReceiverModule : IReceiver<RuneInstance> {
        
        public Action<RuneInstance> ReceiveEvent { get; set; }
        
        public void Receive(RuneInstance data) {
            
        }
    }
}