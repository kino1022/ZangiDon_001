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
        
        [OdinSerialize,LabelText("プレイヤーを取得するクラス")]
        protected ITargetHolder<GameObject> m_player;
        
        [OdinSerialize]
        protected List<IRuneUI> m_slots = new List<IRuneUI>();
        

        public void Start() {

            if (m_player == null) {
                Debug.Log("インスペクター上でITargetHolder<GameObject>がアタッチされていないため自動取得します");
                m_player = GetComponent<ITargetHolder<GameObject>>();
            }
            
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