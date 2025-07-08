using Teiwas.Script.Camera.Angle.Interface;
using UnityEngine;

namespace Teiwas.Script.Camera.Angle {
    public class NormalAngleCalculater : ICameraAngleCalculater {

        protected GameObject m_camera;

        protected GameObject m_target;

        protected GameObject m_player;
        

        public NormalAngleCalculater(
            GameObject camera, GameObject target, GameObject player) {
            m_camera = camera;
            if (camera == null) {
                return;
            }
            m_target = target;
            m_player = player;
            if (m_player == null) {
                return;
            } 
        }

        public Quaternion CalculateAngle() {
            
            var direction = 
                m_target == null ?
                    m_player.transform.forward : m_camera.transform.position - m_target.transform.position;
            
            var result = Quaternion.Euler(direction);
            
            return result;
        }
    }
}