using System.Collections.Generic;
using Project.Script.Bullet.Components.Interface;
using Sirenix.OdinInspector;
using Teiwas.Script.Bullet.Context.Intetface;
using Teiwas.Script.Rune.Effect.Interface;
using UnityEngine;
using VContainer;

namespace Project.Script.Bullet.Components {
    public class BulletEffectHolder : SerializedMonoBehaviour  {
        
        protected List<IEffect> m_effects = new List<IEffect>();

        [Inject]
        public void Construct(IObjectResolver resolver) {
            m_effects = resolver.Resolve<IBulletEffectHolder>().Effects;
        }
        
        public void OnTriggerEnter(Collider other) {
            foreach (var effect in m_effects) {
                effect.Activate(other.gameObject);
            }
        }
    }
}