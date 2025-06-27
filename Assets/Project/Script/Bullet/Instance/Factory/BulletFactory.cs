using Teiwas.Script.Bullet.Context;
using Teiwas.Script.Bullet.Data;
using Teiwas.Script.Bullet.Instance.Interface;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Script.Bullet.Instance.Factory {
    
    public class BulletFactory : IBulletFactory {
        
        protected readonly IObjectResolver m_resolver;
        
        public BulletFactory(IObjectResolver resolver) {
            m_resolver = resolver;
        }

        public GameObject Create(BulletData data, BulletContext context, Vector3 pos, Quaternion rot) {
            var instance = m_resolver.Instantiate(data.Prefab, pos, rot);
            
            return instance;
        }
    }
}