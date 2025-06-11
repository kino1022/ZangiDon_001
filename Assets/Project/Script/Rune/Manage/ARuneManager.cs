using System;
using System.Collections.Generic;
using Project.Script.Interface;
using Project.Script.Rune.Manage.Interface;
using Project.Script.Rune.Manage.Modules;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

//リストに対してモジュールを組み込む方式の方が良さそう。
//つまりこのクラスがリストクラスになってモジュールは従来のまま利用する

namespace Project.Script.Rune.Manage {
    [Serializable]
    public abstract class ARuneManager :　SerializedMonoBehaviour, IDisposable , IRuneListHolder {
        
        [SerializeField,OdinSerialize,LabelText("管理しているルーン")] protected List<RuneInstance> runes;

        [SerializeField, OdinSerialize, LabelText("最大管理ルーン数"),ProgressBar(1,24)] 
        protected int m_manageAmount;
        
        #region modules

        [SerializeField, OdinSerialize, LabelText("ルーン送信モジュール")] protected RuneSenderModule m_sender;
        public ISender<RuneInstance> Sender => m_sender;

        [SerializeField, OdinSerialize, LabelText("ルーン受信モジュール")] protected RuneReceiverModule m_receiver;
        public IReceiver<RuneInstance> Receiver => m_receiver;
        public IReceiveHandler<RuneInstance> ReceiveHandler => m_receiver;
        
        #endregion
        
        
        
        #region ListInterfaces

        public RuneInstance GetRune(int index) {
            return runes[index];
        }

        public List<RuneInstance> GetRuneList() {
            return runes;
        }

        public virtual void SetRune(RuneInstance rune) {
            
        }

        public virtual void RemoveRune(RuneInstance rune) {
            
        }

        public bool GetIsFullList() {
            return runes.Count >= m_manageAmount;
        }

        #endregion
        

        public void Dispose() {
            ReceiveHandler.ReceiveEvent -= OnReceive;
        }
        
        protected abstract void OnReceive(RuneInstance rune);

    }
}