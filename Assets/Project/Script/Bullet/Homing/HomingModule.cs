using Sirenix.OdinInspector;
using VContainer;

namespace Project.Script.Bullet.Homing {
    /// <summary>
    /// 誘導する物体に定義して、誘導の挙動を決定するクラス
    /// </summary>
    public class HomingModule : SerializedMonoBehaviour {
        
        [Inject]
        public void Construct(IObjectResolver resolver) {
            
        }
        
        [Button("誘導実行")]
        public void ExecuteHoming() {
            
        }
    }
}