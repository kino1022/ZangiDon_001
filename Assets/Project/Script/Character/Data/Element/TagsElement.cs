using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Character.Tag.Interface;

namespace Project.Script.Character.Data.Element {
    [Serializable]
    public class TagsElement {
        
        [OdinSerialize, LabelText("キャラクターに付与するタグ")]
        public List<ICharacterTag> Tags;
        
    }
}