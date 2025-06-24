using UnityCommonModule.Correction.Interface;

namespace Teiwas.Script.Bullet.Context.Intetface {
    public interface IBulletDamageCorrection : IBulletContextElement {
        public ICorrector Corrector { get; }
    }
}