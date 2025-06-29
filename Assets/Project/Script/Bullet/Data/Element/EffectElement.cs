using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Rune.Effect.Interface;
using Teiwas.Script.Rune.Interface;

namespace Teiwas.Script.Bullet.Data.Element {
    /// <summary>
    /// ヒット時に対象に対して与える効果を表現するクラス
    /// </summary>
    [Serializable]
    public class EffectElement {
        
        [OdinSerialize, LabelText("発動する効果")]
        public List<IEffect> effects;
        
    }
}