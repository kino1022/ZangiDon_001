using System;
using System.Collections.Generic;
using Project.Script.LockManage;
using Project.Script.Utility;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Camera.Angle.Interface;
using Teiwas.Script.UIControl.Utility;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;

namespace Teiwas.Script.Camera.Angle {
    [Serializable]
    public class TestAngleController : ICameraAngleHolder {

        [SerializeField, LabelText("向くべきアングル"), ReadOnly]
        protected Quaternion m_angle = Quaternion.identity;
        public Quaternion Angle => m_angle;

        [OdinSerialize, LabelText("ターゲットコンテキスト"), ReadOnly]
        protected ITargetContext m_context;
        [OdinSerialize, LabelText("ターゲットコンテキスト保持クラス"), ReadOnly]
        protected ITargetContextHolder m_contextHolder;

        [OdinSerialize, LabelText("アングル制御クラス")]
        protected List<ICameraAngleLimiter> m_limiters = new();
        protected GameObject m_player;
        protected GameObject m_camera;
        protected IObjectResolver m_resolver;

        protected CompositeDisposable m_contextHolderDisposable;

        protected CompositeDisposable m_changeTargetDisposable;

        protected CompositeDisposable m_changeDirectionDisposable;

        public void ControlStart(IObjectResolver resolver, GameObject camera) {

            m_resolver = resolver;

            m_camera = camera;

            m_contextHolder = m_resolver.Resolve<ITargetContextHolder>();

            m_player =
                ComponentsUtility
                    .GetComponentFromWhole<PlayerCharacterHolder>(m_camera)
                    .GetTarget();

            if(m_contextHolder is null) {
                Debug.Log($"{GetType().Name}において、ITargetContextHolderが取得できませんでした");
                return;
            }

            m_context = m_contextHolder.Context;

            ObserveContextChange();
        }

        protected void ObserveContextChange() {

            m_contextHolderDisposable?.Dispose();

            m_contextHolderDisposable = new CompositeDisposable();

            Observable
                .EveryValueChanged(m_contextHolder, x => x.Context)
                .Subscribe(x => {
                    if(x is not null) {
                        m_context = x;
                        ObserveContextTargetChange();
                        ObserveTargetDirectionChange();
                    }
                })
                .AddTo(m_contextHolderDisposable);
        }

        protected void ObserveContextTargetChange() {

            m_changeTargetDisposable?.Dispose();

            m_changeTargetDisposable = new CompositeDisposable();

            Observable
                .EveryValueChanged(m_context, x => x.Target)
                .Subscribe(x => {
                    UpdateAngle();
                })
                .AddTo(m_changeTargetDisposable);
        }

        protected void ObserveTargetDirectionChange() {

            m_changeDirectionDisposable?.Dispose();

            m_changeDirectionDisposable = new CompositeDisposable();

            Observable
                .EveryValueChanged(m_context, x => x.Direction)
                .Subscribe(x => {
                    UpdateAngle();
                })
                .AddTo(m_changeDirectionDisposable);
        }

        protected void UpdateAngle() {
            m_angle = CalculateAngle();
        }

        protected Quaternion CalculateAngle() {

            var angle = new NormalAngleCalculater(m_camera, m_context.Target, m_player).CalculateAngle();

            if(m_limiters is not null || m_limiters.Count is not 0) {
                foreach(var item in m_limiters) {
                    angle = Quaternion.Euler(item.ApplyLimit(angle.eulerAngles));
                }
            }

            return angle;
        }
    }
}
