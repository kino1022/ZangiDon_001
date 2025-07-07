using UnityEngine;

namespace Teiwas.Script.EventBus {
    /// <summary>
    /// なんらかのEntityが生成された際に発火されるEventBus
    /// </summary>
    public struct EntitySpown {

        public GameObject Entity;

        public Vector3 Position;

        public EntitySpown(GameObject entity, Vector3 pos) {
            Entity = entity;
            Position = pos;
        }
        
    }
}
