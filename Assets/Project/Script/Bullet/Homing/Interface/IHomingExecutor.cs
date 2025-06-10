using UnityEngine;

namespace Project.Script.Bullet.Homing.Interface {
    public interface IHomingExecutor {
        public Vector3 ExecuteHoming (Vector3 direction);
    }
}