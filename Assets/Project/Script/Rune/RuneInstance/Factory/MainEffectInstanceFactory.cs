using Teiwas.Script.Rune.Factory.Interface;
using Teiwas.Script.Rune.Interface;
using Teiwas.Script.Rune.Manage.Modules;

namespace Teiwas.Script.Rune.Factory {
    public class MainEffectInstanceFactory : IMainEffectInstanceFactory {
        
        protected readonly RuneData m_data;

        public MainEffectInstanceFactory(RuneData data) {
            m_data = data;
        }

        public IMainEffect Create() {
            return new MainEffectInstance(
                m_data.Main.OnCast,
                new RuneCastCountModule(m_data.Main.Amount)
                );
        }
    }
}