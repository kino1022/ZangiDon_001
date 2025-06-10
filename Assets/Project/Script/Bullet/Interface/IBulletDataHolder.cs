using Project.Script.Bullet.Data;

namespace Project.Script.Bullet.Interface {
    /// <summary>
    /// BulletDataを保持して公開するクラスに対して約束するインターフェース
    /// </summary>
    public interface IBulletDataHolder {
        /// <summary>
        /// BulletDataを取得するメソッド
        /// </summary>
        /// <returns></returns>
        public BulletData GetBulletData();
    }
}