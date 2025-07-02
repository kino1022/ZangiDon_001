using System.Collections.Generic;
using Project.Script.Bullet.Destroy.Conditions;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using VContainer;

namespace Project.Script.Bullet.Destroy {
    /// <summary>
    /// オブジェクトの消滅条件がTrueになるとオブジェクトを消滅させるコンポーネント
    /// </summary>
    public class DestroyConditionManager : SerializedMonoBehaviour {

        [OdinSerialize, LabelText("オブジェクトが破壊される条件")]
        protected List<ADestroyCondition> m_destroyConditions = new List<ADestroyCondition>();
        
        protected CompositeDisposable m_disposables = new CompositeDisposable();
        
        protected IObjectResolver m_resolver;

        [Inject]
        public void Construct(IObjectResolver resolver) {
            m_resolver = resolver;
        }
        
        private void Awake () {

            if (m_destroyConditions.Count == 0 || m_destroyConditions == null) {
                Debug.LogError($"{this.gameObject.name}には消滅条件が定義されていません");
                return;
            }
            
            foreach (var condition in m_destroyConditions) {
                condition.Start(m_resolver);
            }
            
            RegisterCondition();
        } 
        

        private void OnDestroy() {
            m_disposables.Dispose();
        }

        protected void RegisterCondition() {
            foreach (var condition in m_destroyConditions) {
                Observable
                    .EveryValueChanged(condition, x => x.IsDestroy == true)
                    .Subscribe(x => {
                        OnConditionTriggerd();
                    })
                    .AddTo(m_disposables);
            }
        }

        protected void OnConditionTriggerd() {
            GameObject.Destroy(this.gameObject);
        }
    }
}