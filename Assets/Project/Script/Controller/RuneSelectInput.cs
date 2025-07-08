using Sirenix.OdinInspector;
using Teiwas.Script.Rune.Manager.Interface;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Script.Controller {
    public class RuneSelectInput : SerializedMonoBehaviour {
        
        protected IRuneSelector m_selector;

        protected Vector2 m_inputDirection = Vector2.zero;

        public void OnInput(InputAction.CallbackContext context) {
            
            if (context.performed) {
                m_inputDirection = context.ReadValue<Vector2>();
            }

            if (context.canceled) {
                
            }
        }
    }
}