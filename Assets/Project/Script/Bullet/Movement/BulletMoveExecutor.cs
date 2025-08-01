using Project.Script.Utility;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Bullet.Movement.Direction.Interface;
using Teiwas.Script.Bullet.Movement.Interface;
using UnityEngine;

namespace Teiwas.Script.Bullet.Movement {
    /// <summary>
    ///
    /// </summary>
    public class BulletMoveExecutor : SerializedMonoBehaviour {

        [OdinSerialize]
        protected IBulletSpeedHolder m_speed;

        [OdinSerialize]
        protected IMoveDirectionHolder m_direction;

        [SerializeField] protected Vector3 m_movement = Vector3.zero;

        [OdinSerialize]
        protected Rigidbody m_rb;

        private void Awake() {

            m_speed = ComponentsUtility.GetComponentFromWhole<IBulletSpeedHolder>(gameObject);

            if(m_speed == null) {
                enabled = false;
                return;
            }

            m_direction = ComponentsUtility.GetComponentFromWhole<IMoveDirectionHolder>(gameObject);

            if(m_direction == null) {
                enabled = false;
                return;
            }

            m_rb = ComponentsUtility.GetComponentFromWhole<Rigidbody>(gameObject);

            if(m_rb == null) {
                enabled = false;
                return;
            }
        }

        private void Update() {
            UpdateMovement();
            UpdateVelocity();
        }

        protected void UpdateMovement() {
            m_movement = m_speed.Speed * m_direction.Direction;
        }

        protected void UpdateVelocity() {
            m_rb.linearVelocity = m_movement;
        }
    }
}
