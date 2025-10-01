using System;
using System.Collections.Generic;
using MessagePipe;
using Sirenix.OdinInspector;
using VContainer;
using Teiwas.Script.Spell.Instance.Interface;
using Teiwas.Script.Spell.Instance.Main.Interface;
using Teiwas.Script.Spell.Instance.Sub.Insterface;
using Teiwas.Script.Spell.Manager.Container.Interface;
using Teiwas.Script.Spell.Manager.EventBus;
using Teiwas.Script.Spell.Manager.Selector.Interface;
using Teiwas.Script.Spell.Manager.Selector.Module.Interface;
using Teiwas.Script.Spell.Manager.Supplier.Interface;
using Teiwas.Script.Spell.Slot.Selector.Interface;
using Random = UnityEngine.Random;

namespace Teiwas.Script.Spell.Manager.Selector {
    public class SpellSelector : ASpellManager<ISelectorSpellSlot, ISpellInstance> , ISpellSelector {

        protected ISelectSpellContainer m_spellContainer;

        protected IPublisher<OnSelectSpellEventBus> m_publisher;

        protected ISpellSupplier m_supplier;

        protected ISpellSupplyPattern m_supplyPattern;

        protected override void Start() {
            base.Start();

            m_publisher = m_resolver.Resolve<IPublisher<OnSelectSpellEventBus>>()
                          ?? throw new NullReferenceException();

            m_spellContainer = m_resolver.Resolve<ISelectSpellContainer>()
                               ?? throw new NullReferenceException();

            m_supplier = m_resolver.Resolve<ISpellSupplier>()
                         ?? throw new NullReferenceException();

        }

        [Button("選択")]
        public bool Select(int index) {

            if (index < 0 || index >= m_length) {
                throw new IndexOutOfRangeException();
            }

            var slot = m_spells[index] ?? throw new NullReferenceException();

            //これイベントバスで選択されたスペルを他クラスに飛ばしちまおうぜ
            var spell = slot.Select() ?? throw new NullReferenceException();

            //本当に送信可能かの確認処理
            if (spell is IMainSpellInstance && !m_spellContainer.IsMainSendable) {
                return false;
            }
            //同じく本当に送信可能かどうかの確認処理
            if (spell is ISubSpellInstance && !m_spellContainer.IsSubSendable) {
                return false;
            }

            m_publisher.Publish(new OnSelectSpellEventBus(spell));

            return true;
        }

        [Button("補充")]
        public void Supply(int amount) {
            if (amount < 0 || amount > m_length) throw new IndexOutOfRangeException();

            for(var i = 0; i < amount; i++) {
                try {
                    var slot = GetEmptySlot();
                    slot.Value.SetInstance(m_supplyPattern.Supply());
                }
                catch(KeyNotFoundException) {
                    break;
                }

            }
        }
    }
}
