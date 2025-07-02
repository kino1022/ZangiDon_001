using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Diagnostics;
using Teiwas.Script.Rune.Interface;
using UnityEngine;
using Unity.VisualScripting;

namespace Teiwas.Script.Rune.Manage.Modules {
    /// <summary>
    /// ルーンが使用された回数を管理するクラス
    /// </summary>
    [Serializable]
    public class RuneCastCountModule : IRuneDisposeHandler {

        [OdinSerialize, LabelText("残りの使用回数")] private int _count;
        

        protected int m_count
        {
            get { return _count; }
            set
            {
                value = OnPreChangeCount(value);
                _count = value;
                OnPostChangeCount();
            }
        }

        public Action RuneDisposeEvent { get; set; }

        public RuneCastCountModule(int amount)
        {

            if (amount <= 0)
            {
                UnityEngine.Debug.Log("ルーンの使用回数が0以下で初期化されました。処理を中止します。");
            }
            m_count = amount;

    
        }

        public int GetAmount() {
            return m_count;
        }
        
        public void OnCast () {
            m_count--;
        }


        protected virtual int OnPreChangeCount(int value) {
            return value;
        }

        protected virtual void OnPostChangeCount () {

            if (_count <= 0) {
                RuneDisposeEvent?.Invoke();
                return;
            }

        }
    }
}