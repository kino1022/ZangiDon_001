using Project.Script.Bullet.Components.Interface;
using Sirenix.OdinInspector;

namespace Project.Script.Bullet.Components {
    /// <summary>
    /// 弾丸の与えるダメージを管理するコンポーネント
    /// </summary>
    public class BulletDamage : SerializedMonoBehaviour , IDamageHolder {
        
        protected int m_damage = 0;

        


        public int GetDamage()
        {
            return 0;
        }

        public void SetDamage(int damage) {
            
        }
    }
}