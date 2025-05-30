using System;
using Sirenix.OdinInspector;
using UnityCommonModule.CharacterMove.Interface;
using UnityEngine;

namespace Project.Script.MockUpScript.Movement {
    
    public class MockMoveDirectionController : SerializedMonoBehaviour , IDirectionHolder {
        
        [SerializeField] protected Vector3 _direction;
        
        private void Update() {
            _direction.x = Input.GetAxis("Vertical");
            _direction.y = Input.GetAxis("Horizontal");
        }

        public Vector3 GetDirection() {
            return _direction.normalized;
        }
    }
}