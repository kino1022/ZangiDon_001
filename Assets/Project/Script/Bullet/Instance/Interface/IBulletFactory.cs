using Teiwas.Script.Bullet.Context;
using Teiwas.Script.Bullet.Data;
using UnityEngine;

namespace Teiwas.Script.Bullet.Instance.Interface {
    public interface IBulletFactory {
        public GameObject Create(BulletData data,Vector3 pos, Quaternion rot);
    }
}