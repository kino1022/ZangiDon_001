using System.Collections.Generic;
using ObservableCollections;

namespace Teiwas.Script.Character.Tag.Interface {
    public interface ICharacterTagHolder {

        public IReadOnlyObservableList<ICharacterTag> Tags { get; }
        
        public void Add (ICharacterTag tag);
        
        public void Remove (ICharacterTag tag);
    }
}