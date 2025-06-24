using Teiwas.Script.Bullet.Context;
using Teiwas.Script.Bullet.Data;
using Teiwas.Script.Bullet.Instance.Interface;
using UnityEngine;
using VContainer;

namespace Project.Script.Bullet.Instance.Factory {
    
    public class BulletFactory : IBulletFactory {
        
        protected readonly IObjectResolver m_resolver;

        public BulletFactory(IObjectResolver resolver) {
            m_resolver = resolver;
        }

        public void Create(BulletData data, BulletContext context, Vector3 pos, Quaternion rot) {
            
        }
    }
}