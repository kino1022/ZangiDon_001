using Project.Script.Utility;
using Teiwas.Project.Script.Scope;
using Teiwas.Script.Bullet.Context;
using Teiwas.Script.Bullet.Data;
using Teiwas.Script.Bullet.Instance.Interface;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Script.Bullet.Instance.Factory {
    
    public class BulletFactory : IBulletFactory {
        
        protected readonly IObjectResolver m_resolver;
        
        [Inject]
        public BulletFactory(IObjectResolver resolver) {
            m_resolver = resolver;
        }

        public void Create(BulletData data,Vector3 pos, Quaternion rot) {

            if (data == null) {
                Debug.LogError("BulletDataがセットされていない状態でCreateが呼び出されました");
                return;
            }

            var instance = m_resolver.Instantiate(data.Prefab, pos, rot);
        }
    }
}