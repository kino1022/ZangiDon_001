using System;
using Project.Script.Utility;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Asset.MainEffect.Interface;
using Teiwas.Script.Bullet.Data;
using Teiwas.Script.Player.Shoter.Interface;
using Teiwas.Script.Rune.Interface;
using UnityEngine;

namespace Teiwas.Script.Asset.MainEffect {
    /// <summary>
    ///
    /// </summary>
    [Serializable]
    [LabelText("メイン効果：オブジェクト生成")]
    public class InstanceAnyObject : IMainEffectData {

        [SerializeField, LabelText("使用回数"), ProgressBar(0, 20)]
        protected int m_amount = Mathf.Min(0, 0);

        public int Amount => m_amount;

        [SerializeField, LabelText("生成物")]
        protected BulletData m_instanceData;

        [OdinSerialize, LabelText("生成ポジション")]
        protected IInstancePositionHolder m_instancePosition;

        [OdinSerialize, LabelText("生成角")]
        protected IInstanceRotationHolder m_instanceRotation;

        public void OnCast(GameObject caster) {

            if(caster is null) throw new ArgumentNullException(nameof(caster));

            if(Amount < 0) {
                Debug.LogError($"{GetType().Name}が使用回数0以下の状態でOnCastを実行しました");
                return;
            }

            var shoter = ComponentsUtility.GetComponentFromWhole<IPlayerBulletShoter>(caster);

            if(shoter is null) {
                Debug.LogError($"{caster.name}にIPlayerBulletShoterを継承したコンポーネントがアタッチされていませんでした");
                return;
            }

            shoter?.OnShot(
                m_instanceData,
                m_instancePosition.Position(caster),
                m_instanceRotation.Rotation(caster)
                );
        }
    }
}
