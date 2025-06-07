using System;
using Project.Script.Rune.Manage.Modules;
using Project.Script.Rune.Manage.RuneSelector.Module;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Rune.Manage.RuneSelector {
    [Serializable]
    public class RuneSelector : ARuneManager {
        
        [OdinSerialize,SerializeField,LabelText("送信対象セレクター")] protected SendTargetSelector m_list;

        [OdinSerialize, SerializeField, LabelText("一文字目を管理するクラス")]
        protected ARuneManager m_mainSlot;
        
        [OdinSerialize,SerializeField,LabelText("二文字目以降を管理するクラス")] 
        protected ARuneManager m_supportSlot;
    }
}