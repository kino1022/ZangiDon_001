using Sirenix.OdinInspector;
using UnityCommonModule.CharacterMove.Interface;
using UnityEngine;

namespace Project.Script.MockUpScript.Movement {
    public class MockForceController : SerializedMonoBehaviour , IForceHolder {
        
        [SerializeField] protected float m_force = 1.0f;

        public float GetForce() {
            return m_force;
        }
    }
}