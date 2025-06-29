using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Rune.Manager.Interface;
using UnityEngine.InputSystem;
using VContainer;

namespace Mock {
    public class MockController : SerializedMonoBehaviour {

        protected IRuneSelector m_selector;

        [Inject]
        public void Costruct(IObjectResolver resolver) {
            m_selector = resolver.Resolve<IRuneSelector>();
        }

        public void Select_1(InputAction.CallbackContext context) {
            if (context.performed) {
                m_selector.RuneSelected(0);
            }
        }
        public void Select_2(InputAction.CallbackContext context) {
            if (context.started) {
                m_selector.RuneSelected(1);
            }
        }
        public void Select_3(InputAction.CallbackContext context) {
            if (context.started) {
                m_selector.RuneSelected(2);
            }
        }
        public void Select_4(InputAction.CallbackContext context) {
            if (context.started) {
                m_selector.RuneSelected(3);
            }
        }
        public void Select_5(InputAction.CallbackContext context) {
            if (context.started) {
                m_selector.RuneSelected(4);
            }
        }
        public void Select_6(InputAction.CallbackContext context) {
            if (context.started) {
                m_selector.RuneSelected(5);
            }
        }
 
    }
}