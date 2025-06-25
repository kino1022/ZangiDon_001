using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Bullet.Data.Element;
using Teiwas.Script.Character.Tag.Interface;
using UnityEngine;

namespace Teiwas.Script.Bullet.Data {
    [CreateAssetMenu(menuName = "Project/Bullet/BulletData")]
    public class BulletData : SerializedScriptableObject {

        [OdinSerialize, TitleGroup("ダメージ"),LabelText("ダメージ"), ProgressBar(0, 9999)]
        public int BaseDamage;
        
        [OdinSerialize, TitleGroup("ノックバック"), LabelText("ノックバック")]
        public KnockBackElement  KnockBack = new KnockBackElement();
        
        [OdinSerialize, TitleGroup("特効")]
        public Dictionary<ICharacterTag, float> Specific;
        
        [OdinSerialize, TitleGroup("効果")]
        public EffectElement Effect = new EffectElement();

    }
}