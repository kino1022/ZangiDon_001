using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Mock {
    public class MockCharacterController : SerializedMonoBehaviour {

        [SerializeField]
        protected float m_radius = 100.0f;

        [SerializeField]
        protected Vector3 m_origin = new Vector3(0.0f, 0.0f, 0.0f);

        [SerializeField]
        protected float m_speed = 10.0f;

        [SerializeField]
        protected float m_angle = 0.0f;


        private void Update() {
            m_angle += m_speed * Time.deltaTime;

            // 三角関数を使ってX座標とZ座標を計算
            float x = m_origin.x + Mathf.Cos(m_angle) * m_radius;
            float z = m_origin.z + Mathf.Sin(m_angle) * m_radius;
            // Y座標は中心のY座標を維持
            float y = m_origin.y;

            // オブジェクトの位置を更新
            transform.position = new Vector3(x, y, z);
        }
    }
}
