using UnityCommonModule.Target.Interface;
using UnityEngine;

namespace Project.Script.LockManage {
    public interface ILockTargetHolder :  ITargetHolder<GameObject> {
        public void SetTarget(GameObject target);
    }
}
