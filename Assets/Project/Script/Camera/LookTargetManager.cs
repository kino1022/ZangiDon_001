using Sirenix.OdinInspector;
using UnityCommonModule.Target.Interface;
using UnityEngine;

namespace Project.Script.Camera {
    public class LookTargetManager : SerializedMonoBehaviour , ITargetHolder<Transform> {
        
        [SerializeField] protected GameObject m_target;
        
        //-----------------------API Methods----------------------------------------
        
        public Transform GetTarget() {
            return m_target.transform;
        }

        public void SetTarget(GameObject target) {
            m_target = target;
        }
    }
}