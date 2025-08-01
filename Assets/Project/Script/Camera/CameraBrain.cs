using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Camera.Angle.Interface;
using Teiwas.Script.Camera.Position.Interface;
using Teiwas.Script.Camera.Smooth.Interface;
using UnityEngine;
using VContainer;

namespace Teiwas.Script.Camera {
    /// <summary>
    /// 与えられた要素から得られる情報に則ってカメラの制御を行うコンポーネント
    /// </summary>
    public class CameraBrain : SerializedMonoBehaviour {

        [OdinSerialize, Title("カメラポジション")]
        protected ICameraPositionHolder m_pos;

        [OdinSerialize, Title("カメラアングル")]
        protected ICameraAngleHolder m_angle;

        [OdinSerialize, Title("アングル変化の滑らかさ")]
        protected ISmoothHolder m_angleSmooth;

        [OdinSerialize, Title("カメラ移動の滑らかさ")]
        protected ISmoothHolder m_moveSmooth;

        protected IObjectResolver m_resolver;

        [Inject]
        public void Construct(IObjectResolver resolver) {

            Debug.Log($"{GetType().Name}のInjectionを開始します");

            m_resolver = resolver;

            if(m_resolver is null) {
                Debug.Log($"{GetType()}にIObjectResolverが注入されていませんでした");
            }
        }

        protected void Start() {

            if(m_resolver is null) {
                Debug.Log($"{GetType()}にIObjectResolverが注入されていませんでした");
            }

            m_pos?.ControlStart(m_resolver, gameObject);
            m_angle?.ControlStart(m_resolver, gameObject);
            m_moveSmooth?.ControlStart(m_resolver, gameObject);
            m_angleSmooth?.ControlStart(m_resolver, gameObject);

            transform.position = m_pos.Position;

            transform.rotation = m_angle.Angle;
        }

        private void Update() {

            var angleSmooth = m_angleSmooth == null ? 1.0f : m_angleSmooth.Smooth;

            var moveSmooth = m_moveSmooth == null ? 1.0f : m_moveSmooth.Smooth;

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                m_angle.Angle,
                angleSmooth * Time.deltaTime
                );

            transform.position = Vector3.Lerp(
                transform.position,
                m_pos.Position,
                moveSmooth * Time.deltaTime
                );
        }


    }
}
