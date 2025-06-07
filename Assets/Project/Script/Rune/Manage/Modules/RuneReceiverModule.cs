using System;
using Project.Script.Interface;

namespace Project.Script.Rune.Manage.Modules {
    /// <summary>
    /// ルーンを受信するモジュール
    /// </summary>
    [Serializable]
    public class RuneReceiverModule : IReceiver<RuneInstance> {

        public RuneReceiverModule() {
            
        }

        public void Receive(RuneInstance rune) {
            
        }
    }
}