using Project.Script.Rune.Manage.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Rune.Manage {
    /// <summary>
    /// ルーンのインタンスを一括で管理するコンポーネント
    /// </summary>
    public class RuneInstanceManager : SerializedMonoBehaviour {
        
        [OdinSerialize, SerializeField] protected IRuneSupplier m_supplyer;

        [OdinSerialize, SerializeField] protected IRuneListHolder stockRune;
        
        [OdinSerialize, SerializeField] protected IRuneListHolder castRune;

        #region API Methods

        public IRuneListHolder GetStockRuneList() {
            return stockRune;
        }
        
        public IRuneListHolder GetCastRuneList() {
            return castRune;
        }
        
        /// <summary>
        /// 任意の個数サプライヤーからルーンを補充する
        /// </summary>
        /// <param name="amount"></param>
        public void SupplyRuneToStock(int amount) {
            for (int i = 0; i < amount; i++) {
                stockRune.AddRune(m_supplyer.SupplyRune());
            }
        }
        
        /// <summary>
        /// 指定したルーンをstockからcastに対して渡す
        /// </summary>
        /// <param name="rune"></param>
        public void PassRuneToCast(RuneInstance rune) {
            
            if (GetExistEmptyOnCast()) {
                Debug.Log("CastAreaに空きがないため補充できません");
                return;
            }
            
            stockRune.RemoveRune(rune);
            castRune.AddRune(rune);
        }
        
        /// <summary>
        /// stockの中から指定した番数にあるルーンをcastに対して渡す
        /// </summary>
        /// <param name="index"></param>
        public void PassRuneToCast(int index) {
            
            if (GetExistEmptyOnCast()) {
                Debug.Log("CastAreaに空きがないため補充できません");
                return;
            }

            var rune = stockRune.GetRune(index);
            stockRune.RemoveRune(rune);
            castRune.AddRune(rune);
        }

        #endregion
        
        #region CastRune

        protected bool GetExistEmptyOnCast() {
            
            var runes = castRune.GetAllRunes();
            var count = 0;

            foreach (var rune in runes) {
                if (rune != null)  {
                    count++;
                }
            }
            
            return castRune.GetListSize() > count;
        }
        #endregion
        
    }
}