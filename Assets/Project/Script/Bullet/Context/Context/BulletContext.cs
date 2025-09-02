using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Bullet.Context.Intetface;

namespace Teiwas.Script.Bullet.Context.Context {
    [Serializable]
    public class BulletContext : IBulletContext, IDisposable {

        [OdinSerialize, LabelText("保持している要素")]
        protected List<IBulletContextElement> m_elements = new();
        
        public List<IBulletContextElement> Elements => m_elements;

        public BulletContext(List<IBulletContextElement> elements) {
            m_elements = new(elements);
        }
        
        public void Dispose() {
            throw new NotImplementedException();
        }
    }
}