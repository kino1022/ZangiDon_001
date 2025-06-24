using Teiwas.Script.Bullet.Context;
using Teiwas.Script.Bullet.Data;
using UnityEngine;

namespace Teiwas.Script.Bullet.Instance.Interface {
    public interface IBulletFactory {
        public void Create(BulletData data, BulletContext context, Vector3 pos, Quaternion rot);
    }
}