using Project.Script.Spell.Data.Main.Module.Interface;
using Teiwas.Script.Spell.Data.Interface;

namespace Teiwas.Script.Spell.Data.Main.Interface {
    
    public interface IMainSpellData : ISpellData {

        ISpellCastAction CastAction { get; }
    }
}
