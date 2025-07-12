using System.Collections.Generic;
using UnityEngine;

namespace Teiwas.Script.EventBus {
    /// <summary>
    /// Entityがダメージを負ったのを通知するためのEventBus
    /// </summary>
    public readonly struct EntityTakeDamage {

        public readonly GameObject Entity;

        public readonly float Damage;

        public EntityTakeDamage(GameObject entity, float damage) {
            Entity = entity;
            Damage = damage;
        }

        
    }
}
