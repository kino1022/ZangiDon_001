using Sirenix.OdinInspector;
using UnityEngine;

namespace Mock {
    public class MortionState : SerializedStateMachineBehaviour {

        [SerializeField, LabelText("移動のロック")]
        protected bool m_lockMoving = true;

        [SerializeField, LabelText("自由落下のロック")]
        protected bool m_lockFreeFall = true;

        
    }
}
