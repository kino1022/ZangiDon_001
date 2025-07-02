using Project.Script.Utility;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Bullet.Movement.Direction.Interface;
using Teiwas.Script.Bullet.Movement.Direction.Pattern;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Teiwas.Script.Bullet.Movement.Direction {
    /// <summary>
    /// 物体の移動方向を管理するクラス
    /// </summary>
    public class DirectionManager : SerializedMonoBehaviour, IMoveDirectionHolder {
        [SerializeField, ReadOnly, LabelText("進行方向")]
        protected Vector3 m_direction = Vector3.zero;

        public Vector3 Direction {
            get => m_direction;
            private set => m_direction = value.normalized;
        }
        
        [OdinSerialize, LabelText("移動パターン")]
        protected IDirectionPattern m_pattern;
     
        [Inject]
        protected IObjectResolver m_resolver;
        
        private void Start() {
            m_pattern.StartControl(m_resolver,this.gameObject);
            RegisterControl();
        }
        
        protected void RegisterControl() {
            Observable
                .EveryValueChanged(m_pattern, x => x.Direction)
                .Subscribe(x => {
                    Direction = m_pattern.Direction;
                }).AddTo(this);
        }
    }
}