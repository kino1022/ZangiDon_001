using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Character.Group.Interface;

namespace Project.Script.Character.Group {
    /// <summary>
    /// キャラクターの属するグループを管理するコンポーネント
    /// </summary>
    public class CharacterGroup : SerializedMonoBehaviour , IGroupHolder {

        [OdinSerialize, LabelText("キャラクターの属するグループ")]
        protected List<IGroup> m_groups = new List<IGroup>();

        public List<IGroup> Groups {
            get => m_groups;
            set => m_groups = value;
        }

    }
}
