using System.Linq;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Bullet.Context.Asset;
using Teiwas.Script.Bullet.Context.Intetface;
using Teiwas.Script.Bullet.Movement.Acceleration.Interface;
using Teiwas.Script.Bullet.Movement.FirstSpeed.Interface;
using Teiwas.Script.Bullet.Movement.Interface;
using UnityEngine;

namespace Teiwas.Script.Bullet.Movement {
    public class BulletSpeedManager : SerializedMonoBehaviour, IBulletSpeedHolder {

        [OdinSerialize, LabelText("初速度")]
        protected IBulletFirstSpeedHolder m_firstSpeed;

        [OdinSerialize, LabelText("加速度")]
        protected IBulletAccelerationHolder m_acceleration;

        [SerializeField]
        protected float m_speed = 0.0f;
        public float Speed => m_speed;

        private void Start() {
            InitializeSpeed();
        }

        private void Update() {
            UpdateSpeed();
        }

        public void Apply(IBulletContext context) {

            var element = context.Elements.FirstOrDefault(x => x is FirstSpeedCorrector) as FirstSpeedCorrector;

            if (element == null) {
                Debug.Log($"与えられたContextは{GetType()}の初速度に対する修飾を含んでいませんでした");
                return;
            }

            m_firstSpeed.ApplyCorrect(element.Corrections);

            var acceElement = context.Elements.FirstOrDefault(x => x is AccelerationCorrector) as AccelerationCorrector;

            if (acceElement == null) {
                Debug.Log($"与えられたContextは{this.GetType()}の加速度に対する修飾を含んでいませんでした");
                return;
            }

            m_acceleration.ApplyCorrect(acceElement.Corrections);
        }


        protected virtual void InitializeSpeed() {
            Debug.Log($"{this.gameObject.name}における速度の初期化を行います");

            if (m_firstSpeed == null) {
                Debug.Log($"IBulletFirstSpeedHolderがアタッチされていないため、初速度を0で初期化します");
                m_speed = 0.0f;
                return;
            }

            m_speed = m_firstSpeed.FirstSpeed;
        }

        protected virtual void UpdateSpeed() {
            m_speed += m_acceleration.Acceleration * Time.deltaTime;
        }
    }
}
