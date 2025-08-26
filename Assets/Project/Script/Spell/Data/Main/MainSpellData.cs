using Project.Script.Spell.Data;
using Project.Script.Spell.Data.Main.Module.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Spell.Data.Main.Interface;
using UnityEngine;

namespace Teiwas.Script.Spell.Data.Main {
    [CreateAssetMenu(menuName = "Project/Spell/Data/Main")]
    public class MainSpellData : ASpellData , IMainSpellData {
        
        [TitleGroup("性能")]
        [OdinSerialize]
        [LabelText("使用時の効果")]
        protected ISpellCastAction m_CastAction;
        
        public ISpellCastAction CastAction => m_CastAction;
    }
}