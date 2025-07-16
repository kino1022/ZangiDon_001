using Teiwas.Script.Bullet.Data;
using UnityEngine;

namespace Teiwas.Script.Player.Shoter.Interface {
    public interface IPlayerBulletShoter {
        public void OnShot(BulletData data, Vector3 pos, Quaternion rot);
    }
}
