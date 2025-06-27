using Project.Script.Bullet.Homing.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Project.Script.Bullet.Homing {
    
    public class HomingForceManager : IHomingForceHolder {
        
        [OdinSerialize, LabelText("誘導の強さ")]
        protected IHomingForce m_force = new HomingForce();
        
        public IHomingForce Force => m_force;

        public void Add(IHomingForce force) {
            m_force.Add(force);
        }
    }
}