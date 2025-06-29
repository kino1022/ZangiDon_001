using System;
using ObservableCollections;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Bullet.Context.Intetface;

namespace Teiwas.Script.Bullet.Context {
    [Serializable]
    public class BulletContext : IBulletContext {

        [OdinSerialize, LabelText("適用する要素")] 
        protected ObservableList<IBulletContextElement> m_elements;

        public IReadOnlyObservableList<IBulletContextElement> Elements => m_elements;

        public void Add(IBulletContext context) {
            
        }
    }
}