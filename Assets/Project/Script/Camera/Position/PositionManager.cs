using System;
using Project.Script.Camera.Position.Interface;
using Project.Script.LockManage;
using Project.Script.Utility;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Target.Interface;
using UnityEngine;
using VContainer;

namespace Teiwas.Script.Camera.Position {
    [Serializable]
    public class PositionManager : IPositionHolder {
        
        [SerializeField, LabelText("カメラの取るべき位置")]
        protected Vector3 m_pos = Vector3.zero;
        
        public Vector3 Position => m_pos;

        [SerializeField, LabelText("プレイヤーのインスタンス")] 
        protected GameObject m_player;

        [OdinSerialize, LabelText("ターゲットしている対象")]
        protected ILockTargetHolder m_target;
        
        [OdinSerialize, LabelText("オフセット管理")]
        protected IOffsetHolder m_offset;

        [Inject]
        public void Construct(IObjectResolver resolver) {
            
            Debug.Log($"{this.GetType().Name}のInjectionを開始します");
            
            m_offset = resolver.Resolve<IOffsetHolder>();
            
            //please null check
            
            m_target = resolver.Resolve<ILockTargetHolder>();
            
            //please null check

            m_player = resolver.Resolve<GameObject>();
            
            //please null check
        }

        private void Update() {
            m_pos = CalculatePosition();
        }
        

        protected Vector3 CalculatePosition() {

            var distance = CalculateDirection() * m_offset.Distance;

            distance.y = m_offset.Higher;
            
            return m_player.transform.position + distance;
        }

        protected Vector3 CalculateDirection() {
            
            var dir = m_target.GetTarget().transform.position - m_player.transform.position;

            return dir.normalized * -1.0f;
        }
    }
}