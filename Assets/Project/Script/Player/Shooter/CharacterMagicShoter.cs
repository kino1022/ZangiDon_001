using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Bullet.Context.Intetface;
using Teiwas.Script.Bullet.Data;
using Teiwas.Script.Bullet.Instance.Interface;
using UnityEngine;
using VContainer;

namespace Project.Script.Character.Shoter {
    public class CharacterMagicShoter : SerializedMonoBehaviour {

        [OdinSerialize, LabelText("生成に利用するFactory")]
        protected IBulletFactory m_factory;

        [Inject]
        public void Construct(IBulletFactory factory) {
            Debug.Log($"{name}のinjectionを実行します");
            m_factory = factory;

            if(m_factory == null) {
                Debug.LogError($"IBulletFactoryのInjectionが正常に行われませんでした");
                return;
            }
        }

        [Button("射撃")]
        public void OnShot(BulletData data, Vector3 pos, Quaternion rot) {
            m_factory.Create(data, pos, rot);
        }

    }
}
