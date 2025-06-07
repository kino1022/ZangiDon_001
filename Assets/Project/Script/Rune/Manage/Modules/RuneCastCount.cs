using Project.Script.Rune.Manage.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Diagnostics;
using UnityEngine;
using Unity.VisualScripting;

namespace Project.Script.Rune.Manage.Modules {
    /// <summary>
    /// ���[�����g�p���ꂽ�񐔂��Ǘ�����N���X
    /// </summary>
    [Serializable]
    public class RuneCastCountModule : IRuneDisposeHandler {

        [OdinSerialize, LabelText("�c��̎g�p��")] private int _count;

        protected int m_count {
            get { return _count; }
            set {
                value = OnPreChangeCount(value);
                _count = value;
                OnPostChangeCount();
            }
        }

        [OdinSerialize, LabelText("�Ǘ����Ă��郋�[��")] protected RuneInstance m_rune;

        public Action<RuneInstance> RuneDisposeEvent { get; set; }

        public RuneCastCountModule (int amount,RuneInstance rune) {

            if (amount <= 0) {
                UnityEngine.Debug.Log("���[���̎g�p�񐔂�0�ȉ��ŏ���������܂����B�����𒆎~���܂��B");
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