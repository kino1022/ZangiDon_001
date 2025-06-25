using Project.Script.Character.Data.Element;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Project.Script.Character.Data {
    public class CharacterData : SerializedScriptableObject {
        
        [OdinSerialize, LabelText("ステータスのデータ"), Title("ステータス")]
        public StatusElement Status;
        
        [OdinSerialize, LabelText("<UNK>")]
        public TagsElement Tags;
    }
}