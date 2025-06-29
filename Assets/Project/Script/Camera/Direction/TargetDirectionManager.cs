using System;
using Project.Script.Camera.Direction.Interface;
using Project.Script.LockManage;
using UnityCommonModule.CharacterMove.Interface;
using UnityCommonModule.Target.Interface;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Script.Camera.Direction {
    [Serializable]
    public class TargetDirectionManager : ITargetDirectionHolder, ITickable {

        protected ITargetHolder<GameObject> m_target;

        protected GameObject m_camera;

        protected Vector3 m_direction = Vector3.zero;

        [Inject]
        public TargetDirectionManager(ITargetHolder<GameObject> player, GameObject camera) {
            m_target = player;
            m_camera = camera;
        }
        
        public void Tick() {
            
            if (!CheckIntegrity()) {
                Debug.Log("整合性検査に不合格なため、Tick処理を中断します");
                return;
            }
            
            CalculateDirection();
        }

        public Vector3 GetDirection() {
            return m_direction;
        }

        private void CalculateDirection() {
            
            var result = m_target.GetTarget().transform.position - m_camera.transform.position.normalized;
            
            m_direction = result.normalized;
        }

        protected bool CheckIntegrity() {
            
            if (m_camera == null) {
                Debug.Log("Cameraのゲームオブジェクトが存在しません");
                return false;
            }

            if (m_target == null) {
                Debug.Log("プレイヤーのターゲット管理クラスが取得されていません");
                return false;
            }
            
            return true;
        }
    }
}