using Project.Script.Camera.Interface;
using Project.Script.Interface;
using Sirenix.OdinInspector;
using UnityCommonModule.Target.Interface;
using UnityEngine;

namespace Project.Script.Camera {
    public class PositionManager : SerializedMonoBehaviour , IPositionHolder {

        [SerializeField] protected IOffsetHolder m_offset;
        
        [SerializeField] protected ITargetHolder<Transform> m_master;
        
        [SerializeField] protected ITargetHolder<Transform> m_target;

        //-----------------------API Methods---------------------
        
        public Vector3 GetPosition() {
            return CalculatePosition();
        }
        
        //-----------------------Logical methods--------------------
        
        /// <summary>
        /// カメラの取るべき座標を算出するメソッド
        /// </summary>
        /// <returns></returns>
        public Vector3 CalculatePosition() {
            var direction = CalculateOffsetDirection();
            var offset = m_offset.GetOffset();
            return new Vector3(direction.x * offset.x, offset.y, direction.z * offset.z) + m_master.GetTarget().position;
        }

        protected Vector3 CalculateOffsetDirection() {
            var direction =(m_target.GetTarget().position - m_master.GetTarget().position).normalized;
            return direction * -1.0f;
        }
    }
}