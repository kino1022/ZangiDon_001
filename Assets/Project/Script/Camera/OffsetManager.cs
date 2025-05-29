using Project.Script.Camera.Interface;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Script.Camera {
    /// <summary>
    /// カメラの取るオフセットを管理するコンポーネント
    /// </summary>
    public class OffsetManager : SerializedMonoBehaviour , IOffsetHolder {

        [SerializeField] protected Vector3 m_offset;
        
        //------------------API Methods----------------------------------
        
        public Vector3 GetOffset() {
            return m_offset;
        }

        public void SetOffset(Vector3 offset) {
            m_offset = offset;
        }
        
    }
}