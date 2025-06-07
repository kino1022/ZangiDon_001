using System;
using Project.Script.Interface;
using Project.Script.Rune.Manage.Interface;
using Project.Script.Rune.Manage.Modules;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Rune.Manage {
    [Serializable]
    public abstract class ARuneManager {
        
        [SerializeField,OdinSerialize,LabelText("ルーン送信モジュール")] protected RuneSenderModule m_sender;
        
        public ISender<RuneInstance> Sender => m_sender;
        
        [SerializeField,OdinSerialize,LabelText("ルーン受信モジュール")] protected RuneReceiverModule m_receiver;
        
        public IReceiver<RuneInstance> Receiver => m_receiver;

        [SerializeField, OdinSerialize, LabelText("<UNK>")] protected RuneListModule m_list;
        
        public IRuneListHolder List => m_list;
    }
}