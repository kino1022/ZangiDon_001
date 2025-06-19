using System.Collections.Generic;
using Project.Script.Rune.Interface;
using Project.Script.UIControl.PlayerHUD.RuneSelector.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Target.Interface;
using UnityEngine;

namespace Project.Script.UIControl.PlayerHUD.RuneSelector {
    public class RuneSelectorView : SerializedMonoBehaviour , IRuneSelectorView {
        
        [OdinSerialize,LabelText("プレイヤーを取得するクラス")]
        protected ITargetHolder<GameObject> m_player;
        
        [OdinSerialize]
        protected List<ISelectorSlot> m_slots = new List<ISelectorSlot>();
        

        public void Start() {
            new RuneSelectorPresenter(m_player.GetTarget(),this);
        }

        public void Set(int index, IRune rune) {
            m_slots[index].Set(rune);
        }

        public void Remove(int index) {
            m_slots[index].Remove();
        }
        
        
    }
}