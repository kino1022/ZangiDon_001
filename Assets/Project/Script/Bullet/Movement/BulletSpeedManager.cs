using System.Linq;
using Project.Script.Bullet.Movement.Acceleration.Interface;
using Project.Script.Bullet.Movement.Interface;
using Project.Script.Bullet.Movement.Speed.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Bullet.Context.Asset;
using Teiwas.Script.Bullet.Context.Intetface;
using UnityEngine;

namespace Teiwas.Script.Bullet.Movement {
    public class BulletSpeedManager : SerializedMonoBehaviour, IBulletSpeedHolder {

        [OdinSerialize]
        protected IBulletFirstSpeedHolder m_firstSpeed;
        
        [OdinSerialize]
        protected IBulletAccelerationHolder m_acceleration;

        [SerializeField] protected float m_speed = 0.0f;
        
        public float Speed => m_speed;

        private void Update() {
            UpdateSpeed();
        }
        
        public void Apply(IBulletContext context) {
            
            var element = context.Elements.FirstOrDefault(x => x is FirstSpeedCorrector) as FirstSpeedCorrector;

            if (element == null) {
                Debug.Log($"与えられたContextは{this.GetType()}の初速度に対する修飾を含んでいませんでした");
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

        protected void UpdateSpeed() {
            m_speed = m_firstSpeed.FirstSpeed + m_acceleration.Acceleration * Time.deltaTime;
        }
    }
}