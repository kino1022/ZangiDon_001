using Teiwas.Script.Camera.Position.Interface;
using UnityEngine;

namespace Teiwas.Script.Camera.Position {
    public class NormalPositionCalculator : ICameraPositionCalculator {

        protected GameObject m_player;
        protected GameObject m_target;
        protected ICameraOffSetHolder m_offset;

        public NormalPositionCalculator(GameObject player, GameObject target, ICameraOffSetHolder offset) {
            m_player = player;

            if(m_player == null) {
                //Debug.LogError($"{GetType().Name}の初期化時に追従対象がセットされませんでした");
                return;
            }

            m_target = target;
            m_offset = offset;

            if(m_offset == null) {
                //Debug.LogError($"{GetType().Name}の初期化時にオフセット管理クラスが渡されませんでした");
            }

        }

        public Vector3 Calculate() {
            var result = CalculateDirection() * m_offset.Distance;
            result.y = m_offset.Height;

            return m_player.transform.position + result;
        }

        protected Vector3 CalculateDirection() {
            if(m_target != null) {
                return (m_player.transform.position - m_target.transform.position).normalized;
            }
            else {
                return m_player.transform.forward.normalized;
            }
        }
    }
}
