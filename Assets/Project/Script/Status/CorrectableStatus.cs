using Project.Script.Rune.Effect.Interface;
using Project.Script.Status.Interface;
using UnityCommonModule.Correction;
using UnityEngine;

namespace Project.Script.Status {
    public class CorrectableStatus : StatusBase, ICorrectable{

        [SerializeField] protected CorrectedValueElements m_corrected; 

        [SerializeField] protected CorrectionManager m_correction;
        
        //-----------------------API Methods------------------------

        public virtual void Correct(ACorrection correction) { }

        public override void Set(float value) {
            base.Set(value);
            SetCorrectedValue();
        }

        public override void Increase(float value) {
            base.Increase(value);
            SetCorrectedValue();
        }

        public override void Decrease(float value) {
            base.Decrease(value);
            SetCorrectedValue();
        }

        public override float GetValue() {
            return m_corrected.GetValue();
        }
        
        //---------------------SetUp Methods-----------------------

        protected virtual void SetUpCorrectedValue() {
            CreateCorrectedValue();
            AddListenerCorrectedValue();
        }
        
        //----------------------Create Methods----------------------

        protected virtual void CreateCorrectedValue() {
            m_corrected = new CorrectedValueElements(m_statusData.InitialValue);
        }
        
        //----------------------Listener Methods------------------

        protected virtual void AddListenerCorrectedValue() {
            m_corrected.ValueChangeEvent += OnCorrectedValueChanged;
        }

        protected virtual void RemoveListenerCorrectedValue() {
            m_corrected.ValueChangeEvent -= OnCorrectedValueChanged;
        }

        protected virtual void AddListenerRequireCorrect() {
            if (m_correction == null) return;
            
            m_correction.RequireExecuteEvent += OnRequireCorrect;
        }

        protected virtual void RemoveListenerRequireCorrect() {
            if (m_correction == null) return;
            
            m_correction.RequireExecuteEvent -= OnRequireCorrect;
        }
        
        //----------------------Logical methods---------------------

        protected void SetCorrectedValue() {
            m_corrected.Set(
                m_correction.ExecuteCorrection(
                    m_baseValue.GetValue()
                    )
                );
        }
        
        //---------------------hook point----------------------------
        
        protected virtual void OnCorrectedValueChanged(float value) {}
        
        protected virtual void OnRequireCorrect () {}

        protected override void OnInitialize() {
            base.OnInitialize();
            SetUpCorrectedValue();
            AddListenerRequireCorrect();
        }

        protected override void OnDispose() {
            base.OnDispose();
            RemoveListenerCorrectedValue();
            RemoveListenerRequireCorrect();
        }
    }
}