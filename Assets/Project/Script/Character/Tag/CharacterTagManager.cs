using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ObservableCollections;
using Project.Script.Character.Data;
using Project.Script.Character.Data.Interface;
using Project.Script.Utility;
using Sirenix.OdinInspector;
using Teiwas.Script.Character.Tag.Interface;
using UnityEditorInternal;
using UnityEngine;

namespace Teiwas.Script.Character.Tag {
    public class CharacterTagManager : SerializedMonoBehaviour , ICharacterTagHolder {

        protected ObservableList<ICharacterTag> m_tags;
        public IReadOnlyObservableList<ICharacterTag> Tags => m_tags;

        private void Start() {
            var data = ComponentsUtility.GetComponentFromWhole<ICharacterDataHolder>(this.gameObject);

            if (data == null) {
                return;
            }

            foreach (var tag in data.Data.Tags.Tags) {
                Add(tag);
            }
        }

        public List<ICharacterTag> GetTags() {
            return m_tags.ToList();
        }

        public void Add(ICharacterTag tag) {
            m_tags.Add(tag);
        }

        public void Remove(ICharacterTag tag) {
            var target = m_tags.FirstOrDefault(x => x == tag);

            if (target == null) {
                Debug.LogError($"除外対象に指定された{tag.GetType()}が存在しませんでした");
                return;
            }

            m_tags.Remove(target);
        }
    }
}
