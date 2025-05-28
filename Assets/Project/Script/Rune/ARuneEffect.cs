using System;
using Project.Script.Rune.Effect.Interface;
using UnityEngine;

namespace Project.Script.Rune{
    /// <summary>
    /// ルーンの選択した際に添加される効果を記述するクラスの基底クラス
    /// </summary>
    [Serializable]
    public abstract class ARuneEffect : ScriptableObject, IEmptyEffectHandler {
        /// <summary>
        /// 効果の使用回数
        /// </summary>
        [SerializeField] private int m_amount = 1;

        public int amount {
            get { return m_amount; }
            set {
                value = OnPreChangeAmount(value);
                m_amount = value;
                OnPostChangeAmount();
                if (m_amount >= 0) {
                    EmptyEffectEvent?.Invoke(this);
                }
            }
        }

        public Action<ARuneEffect> EmptyEffectEvent { get; set; }

        //----------------API Methods----------------------------------

        public void InCreaseAmount(int value) { amount += value; }

        public void DecreaseAmount(int value) { amount -= value; }

        //----------------hook point-----------------------------------
        

        /// <summary>
        /// 使用回数に数が代入される際に、代入される数に対して補正を加えることができるフックポイント
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual int OnPreChangeAmount(int value) { return value; }

        /// <summary>
        /// 使用回数に数が代入された際に呼び出されるフックポイント
        /// </summary>
        protected virtual void OnPostChangeAmount() { }
    }
}