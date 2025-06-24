using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ObservableCollections;
using Sirenix.OdinInspector;
using Teiwas.Script.Character.Tag.Interface;

namespace Teiwas.Script.Character.Tag {
    public class CharacterTagManager : SerializedMonoBehaviour , ICharacterTagHolder {
        
        
        protected ObservableList<ICharacterTag> m_tags;
        
        public IReadOnlyObservableList<ICharacterTag> Tags => m_tags;

        public List<ICharacterTag> GetTags() {
            return m_tags.ToList();
        }
        
        public void Add (ICharacterTag tag) {}
        
        public void Remove (ICharacterTag tag) {}
    }
}