using Sirenix.OdinInspector;
using Teiwas.Script.Character.Group.Interface;
using UnityEngine;

namespace Project.Script.Character.Group {
    [CreateAssetMenu(menuName = "Project/Character/Group")]
    public class Group : SerializedScriptableObject , IGroup {

        public Color GroupColor;

        public string GroupName;


    }
}
