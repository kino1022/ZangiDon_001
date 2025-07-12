using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.LockManage {
    public class LockTargetManger : SerializedMonoBehaviour , ILockTargetHolder {

        [OdinSerialize] protected GameObject m_target;

        public GameObject GetTarget() => m_target;

        public void SetTarget(GameObject target) {

            if(target is null) {
                Debug.LogError($"{GetType().Name}に代入されたターゲットがnullでした");
                return;
            }

            m_target = target;
        }
    }

}
