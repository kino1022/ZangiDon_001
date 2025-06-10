using Project.Script.Bullet.Homing.Interface;
using Project.Script.Bullet.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Target.Interface;
using UnityEngine;

namespace Project.Script.Bullet.Homing {
    [LabelText("誘導管理")]
    public class HomingDirectionModule : SerializedMonoBehaviour , IHomingExecutor {
        
        [OdinSerialize, LabelText("誘導対象")] protected ITargetHolder<GameObject> m_target;
        
        [OdinSerialize, LabelText("データ保持クラス")] protected IBulletDataHolder m_bulletData;

        public Vector3 ExecuteHoming(Vector3 direction) {
            return Vector3.zero;
        }
        
        
    }
}