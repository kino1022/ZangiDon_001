using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Spell.Data.Interface;
using UnityEngine;

namespace Project.Script.Spell.Data {
    public abstract class ASpellData : SerializedScriptableObject , ISpellData {
        
        [TitleGroup("設定")]
        [LabelText("スペル名")]
        [SerializeField]
        protected string m_spellName;

        [TitleGroup("設定")]
        [LabelText("アイコン")] 
        [SerializeField]
        protected Sprite m_sprite;

        [TitleGroup("使用可能回数")] [LabelText("最大使用可能回数")] [ProgressBar(0, 50)]
        [OdinSerialize]
        protected int m_maxAmount = 0;
        
        public string SpellName => m_spellName;
        
        public Sprite Sprite => m_sprite;
        
        public int MaxAmount => m_maxAmount;
        
    }
}