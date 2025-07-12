using System;
using Sirenix.OdinInspector;

namespace Project.Script.Character.Data.Element {
    [Serializable]
    public class StatusElement {
        
        [TitleGroup("体力初期値"), ProgressBar(0, 9999)]
        public int InitialHealth = 0;
        
        [TitleGroup("付与するタグ")]
        public TagsElement Tags;
        
    }
}