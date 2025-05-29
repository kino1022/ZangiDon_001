using Project.Script.Camera.Interface;
using Project.Script.Interface;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Script.Camera {
    public class PositionManager : SerializedMonoBehaviour , IPositionHolder {

        [SerializeField] protected Vector3 m_position;

        [SerializeField] protected IOffsetHolder m_offset;


        public Vector3 GetPosition() {
            return m_position;
        }
    }
}