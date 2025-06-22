using System.Collections.Generic;
using Project.Script.UIControl.PlayerHUD.Rune.RuneUI.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Rune.Interface;
using Teiwas.Script.UIControl.PlayerHUD.RuneSelector.Interface;
using UnityCommonModule.Target.Interface;
using UnityEngine;

namespace Teiwas.Script.UIControl.PlayerHUD.RuneSelector {
    public class RuneSelectorView : SerializedMonoBehaviour , IRuneSelectorView {
        
        [OdinSerialize]
        protected List<IRuneUI> m_slots = new List<IRuneUI>();

        public void Set(int index, IRune rune) {
            m_slots[index].Set(rune);
        }

        public void Remove(int index) {
            m_slots[index].Remove();
        }
    }
}