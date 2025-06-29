using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.LockManage {
    public class LockTargetManger : SerializedMonoBehaviour , ILockTargetHolder {
        
        [OdinSerialize] protected GameObject m_target;

        public GameObject GetTarget() {
            return m_target;
        } 
        
    }
    
}