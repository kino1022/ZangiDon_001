using System;
using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Instance.Main.Interface;
using Teiwas.Script.Spell.Slot.Main.Interface;
using UnityEngine;

namespace Teiwas.Script.Spell.Slot.Main {
    [Serializable]
    public class MainSpellSlot : IMainSpellSlot {

        protected IMainSpellInstance m_main;

        protected bool m_isEmpty = false;

        public IMainSpellInstance Main => m_main;

        public bool IsEmpty => m_isEmpty;

        public bool SetInstance(ISpellInstance instance) {
            //既にスロットが埋まっていた場合の分岐処理
            if(m_main is not null) {
                //IsEmptyの値が実態と食い違っていた場合の分岐処理
                if(m_isEmpty is true) {
                    m_main = null;
                    m_isEmpty = true;
                }
                return false;
            }

            //引数の型が適当であった場合の分岐処理
            if(instance is IMainSpellInstance main) {
                m_main = main;
                m_isEmpty = false;
                return true;
            }
            else {
                UnityEngine.Debug.Log($"{GetType().Name}に対して所定の変数型と異なる{nameof(instance)}のインスタンスがセットされそうになりました");
                return false;
            }
        }

        public bool RemoveInstance() {
            //既にスロットが空であった場合の分岐処理
            if(m_main is null) {
                //IsEmptyの値が矛盾していた場合の分岐処理
                if(m_isEmpty is false) {
                    Debug.Log("");
                    m_isEmpty = true;
                }
                return false;
            }

            m_main = null;
            m_isEmpty = true;
            return true;
        }
    }
}
