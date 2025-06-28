using System;
using Project.Script.Bullet.Destroy.Interface;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.Rendering;
using VContainer;

namespace Project.Script.Bullet.Destroy {
    public class DestroyConditionManager : SerializedMonoBehaviour {

        [OdinSerialize, LabelText("オブジェクトが破壊される条件")]
        protected ObservableList<IDestroyCondition> m_destroyConditions = new ObservableList<IDestroyCondition>();
        
        protected CompositeDisposable m_disposables = new CompositeDisposable();

        [Inject]
        public void Construct(IObjectResolver resolver) {

            if (m_destroyConditions.Count == 0) {
                Debug.LogError($"{this.gameObject.name}には消滅条件が定義されていません");
                return;
            }
            
            foreach (var condition in m_destroyConditions) {
                condition.Start(resolver);
            }
        } 

        private void Awake() {
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