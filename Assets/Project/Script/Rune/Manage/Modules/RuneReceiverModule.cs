using System;
using Project.Script.Interface;

namespace Project.Script.Rune.Manage.Modules {
    /// <summary>
    /// ルーンを受信するモジュール
    /// </summary>
    [Serializable]
    public class RuneReceiverModule : IReceiver<RuneInstance> , IReceiveHandler<RuneInstance> {
        
        public Action<RuneInstance> ReceiveEvent { get; set; }

        public RuneReceiverModule() {
            
        }

        public void Receive(RuneInstance rune) {
            ReceiveEvent?.Invoke(rune);
        }
    }
}