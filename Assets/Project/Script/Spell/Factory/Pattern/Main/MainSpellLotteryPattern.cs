using System;
using Teiwas.Script.Spell.Data.Main.Interface;
using Teiwas.Script.Spell.Factory.Pattern.Main.Interface;
using VContainer;

namespace Teiwas.Script.Spell.Factory.Pattern.Main {
    [Serializable]
    public class MainSpellLotteryPattern : ASpellLotteryPattern<IMainSpellData>, IMainSpellLotteryPattern {
    }
}