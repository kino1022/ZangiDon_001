using System;
using Project.Script.LockManage;
using Project.Script.Utility;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Camera.Smooth.Interface;
using Teiwas.Script.UIControl.Utility;
using UnityEngine;
using VContainer;

namespace Teiwas.Script.Camera.Smooth {
    /// <summary>
    /// 相対距離に対応して変化するカメラ移動のスムーズさ
    /// </summary>
    [Serializable]
    public class RelativeMoveSmooth : ISmoothHolder {

        [SerializeField, LabelText("最大距離")]
        protected float m_maxRange; //Smoothの変化が起こる最大の距離

        [SerializeField, LabelText("最小距離")]
        protected float m_minRange; //Smoothの変化が発生する最小の距離

        [SerializeField, LabelText("カメラ移動のスムーズさ")]
        protected AnimationCurve m_smoothCurve;

        private float m_rangeRatio = 0.0f;

        protected GameObject m_player;

        [OdinSerialize]
        protected ITargetContextHolder m_context;

        [SerializeField, LabelText("カメラ移動のスムーズさ")]
        protected float m_smooth = Mathf.Clamp(0.0f,0.0f,1.0f);

        public float Smooth => m_smooth;

        public void ControlStart(IObjectResolver resolver, GameObject camera) {

            m_context = resolver.Resolve<ITargetContextHolder>();

            m_player =
                ComponentsUtility
                    .GetComponentFromWhole<PlayerCharacterHolder>(camera)
                    .GetTarget();

            RegisterChangeDistance();

        }

        protected void RegisterChangeDistance() {
            Observable
                .EveryValueChanged(m_context.Context, x => x.Distance)
                .Subscribe(x => {
                    //Debug.Log("敵との相対距離の変化を検知した為、Smoothを変更します");
                    m_rangeRatio = CalculateRangeRatio();
                    m_smooth = m_smoothCurve.Evaluate(m_rangeRatio);
                })
                .AddTo(m_player);
        }

        protected float CalculateRangeRatio() {

            if (m_context.Context.Distance <= m_minRange) return 0.0f;
            if (m_context.Context.Distance >= m_maxRange) return 1.0f;

            return (m_context.Context.Distance - m_minRange) / (m_maxRange - m_minRange);
        }

    }
}
