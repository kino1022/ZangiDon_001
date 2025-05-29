using Project.Script.Camera.Interface;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Script.Camera {
    public class CameraControllerBrain : SerializedMonoBehaviour {
        
        [SerializeField] protected IPositionHolder m_position;
        
        [SerializeField] protected IAngleHolder m_angle;

        [SerializeField] protected float m_smooth = 1.0f;
        
        private void Update() {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                m_angle.GetAngle(),
                m_smooth * Time.deltaTime
                );

            transform.position = Vector3.Lerp(
                this.transform.position,
                m_position.GetPosition(), 
                m_smooth * Time.deltaTime
                );
        }
        
        //-------------------API Methods----------------------------------
        
        //-------------------Logical Methods-----------------------------
    }
}