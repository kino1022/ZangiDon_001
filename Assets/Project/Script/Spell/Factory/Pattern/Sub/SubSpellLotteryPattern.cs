using System;
using Teiwas.Script.Spell.Data.Sub.Interface;
using Teiwas.Script.Spell.Factory.Pattern.Sub.Interface;

namespace Teiwas.Script.Spell.Factory.Pattern.Sub {
    [Serializable]
    public class SubSpellLotteryPattern : ASpellLotteryPattern<ISubSpellData> , ISubSpellLotteryPattern {

    }
}