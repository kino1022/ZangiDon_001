using System;
using Project.Script.Rune.Definition;
using Project.Script.Rune.InstanceElement;
using Project.Script.Rune.Interface;
using Project.Script.Rune.Manage.Definition;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Project.Script.Rune {
    [Serializable]
    public class RuneInstance {
        
        [SerializeField,LabelText("ルーン名")] protected string m_name;
        
        [SerializeField, OdinSerialize, LabelText("使用回数")] 
        protected AmountCounter m_amount;

        [SerializeField, OdinSerialize, LabelText("魔術")] 
        protected ICastable m_magic;

        [SerializeField, OdinSerialize, LabelText("補助効果")] 
        protected SupportEffect m_effect;
        
        /// <summary>
        /// 使用回数が0になる等でルーンが除去される際に呼び出されるイベント
        /// </summary>
        public Action<RuneInstance> RuneDisposeEvent;
        
        public RuneInstance(RuneData data) {
            
        }

        #region API

        public void DisposeRune() {
            OnDisposeRune();
        }

        #endregion

        #region AmountCounter

        public void SetUpCounter(int amount) {
            m_amount = new AmountCounter(amount);
            AddListenerAmount();
        }

        public int GetCurrentAmount() {
            return m_amount.GetCurrentAmount();
        }

        public void IncreaseAmount(int amount) {
            m_amount.IncreaseAmount(amount);
        }

        public void DecreaseAmount(int amount) {
            m_amount.DecreaseAmount(amount);
        }

        protected void AddListenerAmount() {
            m_amount.AmountZeroEvent += OnAmountZero;
        }

        protected void RemoveListenerAmount() {
            m_amount.AmountZeroEvent -= OnAmountZero;
        }

        protected void DisposeCounter() {
            RemoveListenerAmount();
            m_amount = null;
        }

        #endregion
        
        #region Hook Point

            /// <summary>
            /// 魔術が唱えられた際に呼び出されるメソッド
            /// </summary>
            /// <param name="caster"></param>
            public virtual void OnCast(GameObject caster, SelectType type) {
                
                if (type == SelectType.Primary) {
                    OnPrimaryCast(caster);
                }
                else {
                    OnSupportCast(caster);
                }
                
                DecreaseAmount(1);
            }

            protected virtual void OnPrimaryCast (GameObject caster) {
                m_magic.OnCast(caster);
            }

            protected virtual void OnSupportCast (GameObject caster) {
                if (m_effect.GetTiming() == ActivateTiming.OnCast) {
                    m_effect.Activate(caster);
                }
            }
            
            /// <summary>
            /// ストックから選択された際に呼び出されるメソッド
            /// </summary>
            /// <param name="caster"></param>
            /// <param name="type"></param>
            public virtual void OnSelect(GameObject caster, SelectType type) {
                if (type == SelectType.Primary) {
                    OnPrimarySelect(caster);
                }
                else {
                    OnSupportSelect(caster);
                }
            }

            /// <summary>
            /// 一文字目に選択された際に呼び出されるメソッド
            /// </summary>
            /// <param name="caster"></param>
            protected virtual void OnPrimarySelect(GameObject caster) {
                SetUpCounter(m_magic.GetAmount());
            }

            /// <summary>
            /// 二文字目以降に選択された際に呼び出されるメソッド
            /// </summary>
            /// <param name="caster"></param>
            protected virtual void OnSupportSelect(GameObject caster) {
                
                SetUpCounter(m_effect.GetAmount());
                
                if (m_effect.GetTiming() == ActivateTiming.OnSelect) {
                    m_effect.Activate(caster);
                }
                
            }

            /// <summary>
            /// 魔術などのprefabがインスタンスされた際に呼び出されるメソッド
            /// </summary>
            /// <param name="bullet"></param>
            protected virtual void OnBulletInitialize(GameObject bullet) {

                if (m_effect.GetTiming() == ActivateTiming.OnHit) {
                    //弾丸の効果保持コンポーネントに対して渡す処理を記述
                }
                
            }

            protected virtual void OnAmountZero() {
                OnDisposeRune();
            }

            protected virtual void OnDisposeRune() {
                RuneDisposeEvent?.Invoke(this);
            }
            
        #endregion
    }
}