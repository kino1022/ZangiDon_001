using Project.Script.Camera.Interface;
using Sirenix.OdinInspector;
using UnityCommonModule.Target.Interface;
using UnityEngine;

namespace Project.Script.Camera {
    public class RotateManager : SerializedMonoBehaviour , IAngleHolder {
        
        [SerializeField] protected ITargetHolder<Transform> m_target;

        [SerializeField] protected ITargetHolder<Transform> m_maseter;

        [SerializeField] protected float m_angleLimit = 60.0f;
        
        /// <summary>
        /// 例外発生時に向くデフォルトの方向
        /// </summary>
        [SerializeField] protected Vector3 m_defaultDirection = new Vector3(1.0f, 0.0f, 0.0f);
        
        //-------------------API Methods----------------------------------

        public Quaternion GetAngle() {
            return CalculateAngle();
        }
        
        //------------------Logical methods-------------------------------

        protected Quaternion CalculateAngle() {
            var direction = CalculateDirection();
            
            //ゼロベクトルならデフォルトの方向を向く
            if (direction == Vector3.zero) {
                return Quaternion.LookRotation(m_defaultDirection);
            }
            
            return Quaternion.LookRotation(direction);
        }

        protected Vector3 CalculateDirection() {
            var target = m_target.GetTarget().position;
            var master = m_maseter.GetTarget().position;
            
            //対象がいるかどうかのチェック
            if (target == null || master == null || m_target.GetTarget() == null || m_maseter.GetTarget() == null) {
                return m_defaultDirection;//ひっかかった場合はデフォルト値を返す
            }
            
            //ターゲットとマスターの座標不明悪霊殺しが一緒ならデフォルト値を返す
            if (target == master) {
                return m_defaultDirection;
            }
            
            var result = target - master;
            result = OnCalculateDirection(result);
            return result;
        }

        protected Vector3 OnCalculateDirection(Vector3 direction) {
            return ApplicableAngleLimit(direction);
        }

        protected Vector3 ApplicableAngleLimit(Vector3 direction) {
            var result = direction;
            return result;
        }
        
    }
}