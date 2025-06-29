using System.Collections.Generic;
using Teiwas.Script.Bullet.Context.Intetface;
using UnityCommonModule.Correction.Interface;

namespace Project.Script.Asset.Bullet.Context.Interface {
    /// <summary>
    /// 生成物のダメージに対して補正を施すクラスに対して与えるIBulletElementContext
    /// </summary>
    public interface IDamageCorrectionContext : IBulletContextElement {
        
        public List<ICorrection> Corrections { get; }
        
    }
}