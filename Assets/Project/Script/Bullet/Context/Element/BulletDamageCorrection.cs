using Teiwas.Script.Bullet.Context.Intetface;
using UnityCommonModule.Correction;
using UnityCommonModule.Correction.Interface;
using UnityEngine;

namespace Teiwas.Script.Bullet.Context.Element {
    /// <summary>
    /// 弾丸の持つダメージへの補正値を管理するクラス
    /// </summary>
    public class BulletDamageCorrection : IBulletDamageCorrection {
        
        protected CorrectionManager m_corrector = new CorrectionManager();
        
        public ICorrector Corrector => m_corrector;

        public void Apply(GameObject bullet) {
            
        }
        
    }
}