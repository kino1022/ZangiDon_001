using Project.Script.Bullet.Components.Interface;
using Sirenix.OdinInspector;

namespace Project.Script.Bullet.Components {
    /// <summary>
    /// 弾丸の与えるダメージを管理するコンポーネント
    /// </summary>
    public class BulletDamage : SerializedMonoBehaviour , IDamageHolder {


        public int GetDamage() {
            return 0;
        }
    }
}