using System.Collections.Generic;
using UnityCommonModule.Correction.Interface;

namespace Teiwas.Script.Bullet.Context.Intetface {
    /// <summary>
    /// 弾丸のダメージにかかる補正を保持するBulletContextElement
    /// </summary>
    public interface IBulletDamageCorrection : IBulletContextElement {
        public ICorrector Corrector { get; }
        
        public List<ICorrection> Corrections { get; }
    }
}