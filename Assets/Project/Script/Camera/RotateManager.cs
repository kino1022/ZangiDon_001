using Project.Script.Camera.Interface;
using Sirenix.OdinInspector;
using UnityCommonModule.Target.Interface;
using UnityEngine;

namespace Project.Script.Camera {
    public class RotateManager : SerializedMonoBehaviour , IAngleHolder {
        
        [SerializeField] protected ITargetHolder<Transform> m_target;

        [SerializeField] protected ITargetHolder<Transform> m_maseter;
        
        //-------------------API Methods----------------------------------

        public Quaternion GetAngle() {
            return CalculateAngle();
        }
        
        //------------------Logical methods-------------------------------

        public Quaternion CalculateAngle() {
            return Quaternion.LookRotation(CalculateDirection());
        }

        public Vector3 CalculateDirection() {
            return m_target.GetTarget().position - m_maseter.GetTarget().position;
        }
    }
}