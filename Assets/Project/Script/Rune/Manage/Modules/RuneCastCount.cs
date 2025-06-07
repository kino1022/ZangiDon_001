using Project.Script.Rune.Manage.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Diagnostics;
using UnityEngine;
using Unity.VisualScripting;

namespace Project.Script.Rune.Manage.Modules {
    /// <summary>
    /// ルーンが使用された回数を管理するクラス
    /// </summary>
    [Serializable]
    public class RuneCastCountModule : IRuneDisposeHandler {

        [OdinSerialize, LabelText("残りの使用回数")] private int _count;

        protected int m_count {
            get { return _count; }
            set {
                value = OnPreChangeCount(value);
                _count = value;
                OnPostChangeCount();
            }
        }

        [OdinSerialize, LabelText("管理しているルーン")] protected RuneInstance m_rune;

        public Action<RuneInstance> RuneDisposeEvent { get; set; }

        public RuneCastCountModule (int amount,RuneInstance rune) {

            if (amount <= 0) {
                UnityEngine.Debug.Log("ルーンの使用回数が0以下で初期化されました。処理を中止します。");
            }

            m_count = amount;
            m_rune = rune;
        }


        protected virtual int OnPreChangeCount (int value) {
            return value;
        }

        protected virtual void OnPostChangeCount () {

            if (_count <= 0) {
                RuneDisposeEvent?.Invoke(m_rune);
                return;
            }

        }
    }
}