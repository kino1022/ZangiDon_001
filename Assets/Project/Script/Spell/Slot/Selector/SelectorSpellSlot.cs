using System;
using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Instance.Main.Interface;
using Teiwas.Script.Spell.Instance.Sub.Insterface;
using Teiwas.Script.Spell.Slot.Selector.Interface;
using UnityEngine;

namespace Teiwas.Script.Spell.Slot.Selector {
    [Serializable]
    public class SelectorSpellSlot : ISelectorSpellSlot {

        protected ISpellInstance m_spell;

        public ISpellInstance Spell => m_spell;

        protected bool m_isEmpty = true;

        public bool IsEmpty => m_isEmpty;

        public bool SetInstance(ISpellInstance spell) {

            //リストが既に空欄でない場合の分岐処理
            if(m_isEmpty is false) {
                //IsEmptyの状態と実態が矛盾している場合の分岐処理
                if(m_spell is not null) {
                    m_spell = null;
                    m_isEmpty = true;
                    return false;
                }
                return false;
            }

            m_spell = spell
                        ?? throw new ArgumentNullException($"{GetType().Name}にセットされそうになった{nameof(spell)}がnullでした");
            m_isEmpty = false;
            return true;
        }

        public bool RemoveInstance() {

            //スロットにインスタンスが存在しなかった場合の分岐処理
            if(m_spell is null) {
                Debug.Log($"{GetType().Name}にISpellInstanceが存在しませんでした");
                return false;
            }

            m_spell = null;
            m_isEmpty = true;
            return true;
        }
    }
}
