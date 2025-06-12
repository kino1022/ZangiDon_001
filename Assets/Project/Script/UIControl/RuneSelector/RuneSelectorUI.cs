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
        
        [OdinSerialize, LabelText("ルーンスプライト")]
        protected List<Image> m_sprites;
        
        [Inject]
        public void Construct(GameObject character) {
            m_list = character
                .GetComponent<RuneManagerMonoBehaviour>()
                .Selector;
        }
        
        
    }
}