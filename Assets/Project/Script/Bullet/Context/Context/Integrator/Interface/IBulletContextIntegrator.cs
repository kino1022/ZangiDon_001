using System.Collections.Generic;
using Teiwas.Script.Bullet.Context.Intetface;

namespace Teiwas.Script.Bullet.Context.Context.Integrator.Interface {
    /// <summary>
    /// 複数のIBulletContextを統合する処理を行うクラスに対して約束するインターフェース
    /// </summary>
    public interface IBulletContextIntegrator {

        public IBulletContext Integrate(List<IBulletContext> contexts);
        
    }
}