using Project.Script.Interface;
using UnityEngine;

namespace Project.Script.Rune.Manager.Module {
    public class DummySender : ISender<RuneInstance> {


        public void Send(RuneInstance instance) {
            Debug.Log("ダミーのSenderによるルーンの送信が行われました。コードを見直してください");
        }
    }
}