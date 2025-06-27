using Sirenix.OdinInspector;
using Teiwas.Script.Bullet.Context.Intetface;
using UnityCommonModule.Correction;
using UnityCommonModule.Correction.Interface;
using UnityEngine;

namespace Project.Script.Bullet.Damage {
    /// <summary>
    /// 弾丸の持つダメージを管理するクラス
    /// </summary>
    public class DamageManager : SerializedMonoBehaviour , IBulletDamageHolder , IBulletContextApplicable {
        
        [SerializeField, ProgressBar(0,1000)]
        protected int m_damage = Mathf.Min(0, 0);
        
        public int Damage => m_damage;

        protected CorrectionManager m_correction;
        
        public ICorrector Correction => m_correction;


        public void Apply(IBulletContext context) {
            
        }
        
    }
}