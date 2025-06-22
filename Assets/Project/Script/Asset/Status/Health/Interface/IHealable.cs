
using UnityCommonModule.Correction.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace Teiwas.Script.Asset.Status.Health.Interface {
    public interface IHealable {
        
        public UnityEvent<GameObject,int> HealUEvent { get; set; }
        
        /// <summary>
        /// 回復を行うメソッド
        /// </summary>
        /// <param name="amount"></param>
        public void Heal (int amount);
        
        /// <summary>
        /// 補正などを考慮しない固定値での回復を行うメソッド
        /// </summary>
        /// <param name="amount"></param>
        public void InstantHeal (int amount);
        
        /// <summary>
        /// 回復力に対して補正を課すメソッド
        /// </summary>
        /// <param name="correction"></param>
        public void AddCorrection (ICorrection correction);
        
        
        /// <summary>
        /// 回復力にかかっている特定の補正を全て削除するメソッド
        /// </summary>
        /// <param name="target"></param>
        public void RemoveCorrection (ICorrection target);
    }
}