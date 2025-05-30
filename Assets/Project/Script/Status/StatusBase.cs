using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Script.Status {
    public class StatusBase : SerializedMonoBehaviour {
        
        /// <summary>
        /// 補正などをしない元々の値
        /// </summary>
        [SerializeReference] protected BaseValueElement m_baseValue;
        
        [SerializeField] protected StatusData m_statusData;

        [SerializeField] public UnityEvent ValueChangeUEvent;

        private void Awake() {
            SetUpBaseValue();
        }

        private void OnDestroy() {
            RemoveListenerBaseValue();
            OnDispose();
        }

        //-----------------API methods----------------------------

        public virtual void Set(float value) {
            m_baseValue.Set(value);
        }

        public virtual void Increase(float value) {
            m_baseValue.Increase(value);
        }

        public virtual void Decrease(float value) {
            m_baseValue.Decrease(value);
        }

        public virtual float GetValue() {
            return m_baseValue.GetValue();
        }
        
        //-------------SetUp Methods----------------------------

        protected virtual void SetUpBaseValue() {
            CreateBaseValue();
            AddListenerBaseValue();
        }
        
        //--------------Create Methods--------------------------

        protected virtual void CreateBaseValue() {
            m_baseValue = new BaseValueElement(m_statusData.InitialValue);
        }
        
        //---------------Listener methods------------------------

        protected virtual void AddListenerBaseValue() {
            m_baseValue.ValueChangeEvent += OnValueChange;
        }

        protected virtual void RemoveListenerBaseValue() {
            m_baseValue.ValueChangeEvent -= OnValueChange;
        }
        
        //--------------hook point---------------------------------

        private void Initialize() {
            OnInitialize();
        }

        protected virtual void OnInitialize() { }
        
        protected virtual void OnDispose() { }
        
        protected virtual void OnValueChange (float value) {}
    }
}