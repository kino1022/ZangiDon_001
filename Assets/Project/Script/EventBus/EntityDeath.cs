using UnityEngine;

namespace Teiwas.Script.EventBus {
    public struct EntityDeath {
        public GameObject Entity;

        public EntityDeath(GameObject entity) {
            Entity = entity;
        }
    }
}
