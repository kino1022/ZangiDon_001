using System;
using Teiwas.Script.Bullet.Context.Element;
using Teiwas.Script.Bullet.Context.Intetface;

namespace Teiwas.Script.Bullet.Context {
    [Serializable]
    public class BulletContext {
        
        public IBulletDamageCorrection Damage = new BulletDamageCorrection();
    }
}