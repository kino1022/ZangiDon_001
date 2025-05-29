using Sirenix.OdinInspector;
using UnityCommonModule.Target.Interface;
using UnityEngine;

namespace Project.Script.Camera {
    /// <summary>
    /// カメラが追う対象を管理するコンポーネント
    /// </summary>
    public class FollowTargetManager : SerializedMonoBehaviour , ITargetHolder<Transform> {
        /// <summary>
        /// 追従する対象
        /// </summary>
        [SerializeField] protected GameObject m_target;

        public Transform GetTarget() {
            return m_target.transform;
        }
    }
}