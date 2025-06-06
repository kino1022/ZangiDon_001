using Project.Script.LockManage.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Target.Interface;
using UnityEngine;

namespace Project.Script.LockManage {
    
    public class LockTargetManager : ITargetHolder<GameObject>{
        
        [SerializeField, OdinSerialize, LabelText("ロックしている対象")]
        protected GameObject m_target;

        public GameObject GetTarget() {
            return m_target;
        }
        
        
    }
}