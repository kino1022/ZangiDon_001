using Project.Script.Bullet.Target.Interface;
using Project.Script.LockManage;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Project.Script.Bullet.Target {
    /// <summary>
    /// 弾丸が向かう対象を管理するクラス
    /// </summary>
    public class BulletTargetHolder : SerializedMonoBehaviour , IBulletTargetHolder {

        protected GameObject m_target;
        
        
        [Inject]
        public void Construct(IObjectResolver resolver) {

            m_target = resolver.Resolve<ILockTargetHolder>().GetTarget();
        }
        
        public GameObject GetTarget() {
            return m_target;
        }
    }
}