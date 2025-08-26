using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Slot.Interface;
using Teiwas.Script.UIControl.PlayerHUD.Spell.Interface;
using Teiwas.Script.UIControl.PlayerHUD.Spell.Slot;
using VContainer;

namespace Teiwas.Script.UIControl.PlayerHUD.Spell {
    
    public abstract class ASpellManagerView<Slot,Instance> : SerializedMonoBehaviour, ISpellManagerView<Slot,Instance> 
        where Slot : ISpellSlot<Instance>
        where Instance : ISpellInstance{
        
        protected IObjectResolver m_resolver;

        [OdinSerialize]
        protected Dictionary<int, ISpellSlotUIView> m_spells;

        public Dictionary<int, ISpellSlotUIView> Spells {
            get { return m_spells; }
            set { m_spells = value; }
        }
        
        [Inject]
        public void Construct(IObjectResolver resolver) {
            m_resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        public virtual void Start() {
            
        }

        public virtual void Dispose() {
            
        }
        
    }
}