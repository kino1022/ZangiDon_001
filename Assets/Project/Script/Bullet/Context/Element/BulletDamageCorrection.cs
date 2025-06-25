using System.Collections.Generic;
using Project.Script.Bullet.Components.Interface;
using Project.Script.Utility;
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
        
        protected List<ICorrection> m_corrections = new List<ICorrection>();
        
        public ICorrector Corrector => m_corrector;
        
        public List<ICorrection> Corrections => m_corrections;

        public void Apply(GameObject bullet) {
            var damage = ComponentsUtility.GetComponentFromWhole<IDamageHolder>(bullet);

            if (damage != null) {
                damage.SetDamage((int)m_corrector.Execute((float)damage.GetDamage()));
            }
            else {
                Debug.LogError("弾丸にIDamageHolderを継承したコンポーネントが存在しませんでした");
                return;
            }
        }

        public void AddElement(IBulletContextElement element) {
            if (element is IBulletDamageCorrection ele) {
                foreach (var correction in ele.Corrections) {
                    m_corrections.Add(correction);
                }
            }
            else {
                Debug.LogError("IBulletDamageCorrection以外のIBulletContextElementが加算されそうになりました。処理を中断します");
                return;
            }
        }
        
    }
}