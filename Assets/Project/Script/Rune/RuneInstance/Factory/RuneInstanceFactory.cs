using Teiwas.Script.Rune.Factory.Interface;
using Teiwas.Script.Rune.Interface;

namespace Teiwas.Script.Rune.Factory {
    public class RuneInstanceFactory : IRuneInstanceFactory {

        protected readonly RuneData m_data;

        public RuneInstanceFactory(RuneData data) {
            m_data = data;
        }

        public IRune Create() {
            return new RuneInstance(
                m_data.runeSprite,
                new MainEffectInstanceFactory(m_data).Create(), 
                new SubEffectInstanceFactory(m_data).Create()
                );
        }
    }
}