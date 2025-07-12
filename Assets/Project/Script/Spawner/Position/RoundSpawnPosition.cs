using System;
using System.Runtime.Serialization;
using Sirenix.OdinInspector;
using Teiwas.Script.Spawner.Position.Interface;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace Teiwas.Script.Spawner.Position {
    [Serializable, LabelText("円形範囲")]
    public class RoundSpawnPosition : ISpawnPositionManager {

        [SerializeField, LabelText("高さ"), ProgressBar(0.0f, 20.0f)]
        protected float m_height = 0.0f;

        [SerializeField, LabelText("半径"), ProgressBar(0.0f, 200.0f)]
        protected float m_radius = 20.0f;

        protected GameObject m_spawner;

        public void Initialize(IObjectResolver resolver, GameObject spawner) {
            m_spawner = spawner;
        }

        public Vector3 Position() {
            var pos = Random.insideUnitCircle * m_radius;

            var result = new Vector3(pos.x,Random.Range(0.0f,m_height), pos.y) + m_spawner.transform.position;

            return result;
        }
    }
}
