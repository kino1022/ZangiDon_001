using Project.Script.Bullet.Homing.Interface;
using Project.Script.Utility;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Bullet.Homing {
    /// <summary>
    /// RigidBody.AddForce(x,Forcemode.Impuls)を利用して誘導をかけるクラス
    /// </summary>
    public class ImpulsHomingExecutor : SerializedMonoBehaviour , IHomingExecutor {
        
        [OdinSerialize, LabelText("誘導の強さ")] protected IHomingForceHolder m_force;
        
        [OdinSerialize, LabelText("誘導の対象")] protected IHomingTargetHolder m_target;
        

        public void Execute(GameObject bullet) {
            
            var rb = ComponentsUtility.GetComponentFromWhole<Rigidbody>(bullet);
         
            
            rb.AddForce(
                GetHomingValue(m_target.GetTarget(),bullet),
                ForceMode.Impulse
                );
        }

        protected virtual Vector3 GetHomingValue(GameObject target,GameObject bullet) {
            
            if (target == null) {
                Debug.LogError("<UNK>");
                return Vector3.zero;
            }
            
            var value = Vector3.zero;
            
            var direction = target.transform.position - bullet.transform.position;
            
            var local = transform.InverseTransformDirection(direction);

            var absX = Mathf.Abs(local.x);
            var absY = Mathf.Abs(local.y);

            value.x = local.x > 0 ? m_force.Force.Right * Mathf.Abs(direction.x) : m_force.Force.Left * Mathf.Abs(direction.x);
            value.y = local.y > 0 ? m_force.Force.Upper * Mathf.Abs(direction.y) : m_force.Force.Lower * Mathf.Abs(direction.y);
            
            return value;
        }
    }
}