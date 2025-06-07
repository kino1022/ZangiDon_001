using System;
using Project.Script.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Rune.Manage.Modules {
    /// <summary>
    /// RuneInstanceを指定した対象に送信する
    /// </summary>
    [Serializable]
    public class RuneSenderModule : ISender<RuneInstance> {
        [OdinSerialize,LabelText("ルーン受信側インスタンス")]
        protected IReceiver<RuneInstance> m_receiver;

        public RuneSenderModule(IReceiver<RuneInstance> receiver) {

            if (receiver == null) {
                Debug.Log("RuneSenderModuleの初期化の際に受信側が見つかりませんでした");
                return;
            }
            
            m_receiver = receiver;
        }

        public void Send(RuneInstance instance) {

        }
    }
}