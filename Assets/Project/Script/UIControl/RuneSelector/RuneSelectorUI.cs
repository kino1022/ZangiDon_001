using System.Collections.Generic;
using Project.Script.Rune;
using Project.Script.Rune.Manager;
using Project.Script.Rune.Manager.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Project.Script.UIControl.RuneSelector {
    public class RuneSelectorUI : SerializedMonoBehaviour {

        [OdinSerialize, LabelText("セレクターのインスタンス")]
        protected ISelectableRuneList m_list;
        
        [OdinSerialize, LabelText("要素ボックスのprefab")]
        protected GameObject m_elementPrefab;

        protected GameObject m_character;

        [Inject]
        public void Construct(GameObject player) {
            m_list = player.GetComponent<ISelectableRuneList>();
        }
        
        
    }
}