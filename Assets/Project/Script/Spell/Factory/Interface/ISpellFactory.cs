using System;
using Teiwas.Script.Spell.Data.Interface;
using Teiwas.Script.Spell.Instance.Interface;
using VContainer.Unity;

namespace Teiwas.Script.Spell.Factory.Interface {
    public interface ISpellFactory<D,I> : IStartable , IDisposable
        where D : ISpellData  where I : ISpellInstance {

        I Create();

    }
}
