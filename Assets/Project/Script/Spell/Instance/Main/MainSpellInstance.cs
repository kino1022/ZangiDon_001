using System;
using Project.Script.Spell.Instance;
using Teiwas.Script.Spell.Instance.Main.Interface;
using Teiwas.Script.Spell.Instance.Module.Interface;
using UnityEngine;

namespace Teiwas.Script.Spell.Instance.Main {
    [Serializable]
    public class MainSpellInstance : ASpellInstance , IMainSpellInstance {

        protected Action<GameObject> m_oncast;
        
        public Action<GameObject> OnCast => m_oncast;

        public MainSpellInstance(Sprite sprite, string name, IAmountCounter counter, Action<GameObject> onCast) 
            : base(sprite, name, counter) {
            m_oncast = onCast ?? throw new ArgumentNullException(nameof(onCast));
        }
    }
}