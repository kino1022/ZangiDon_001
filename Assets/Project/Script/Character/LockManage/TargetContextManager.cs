using Project.Script.Utility;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Project.Script.LockManage {
    
    public class TargetContextManager : SerializedMonoBehaviour , ITargetContextHolder {
        [OdinSerialize]
        protected ITargetContext m_context;
        
        public ITargetContext Context => m_context;

        private void Awake() {
            CreateNewContext();
        }
        

        private void OnDestroy() {
            m_context.Dispose();
        }

        protected void CreateNewContext() {
            
            m_context = new TargetContext(
                this.gameObject, 
                ComponentsUtility.GetComponentFromWhole<ILockTargetHolder>(this.gameObject)
                );
        }
        
        
    }
}