using System;
using System.Collections.Generic;
using System.Linq;
using Teiwas.Script.Bullet.Context;
using Teiwas.Script.Rune.Effect.Interface;
using Teiwas.Script.Rune.Factory.Interface;
using Teiwas.Script.Rune.Interface;
using Teiwas.Script.Rune.Manage.Modules;

namespace Teiwas.Script.Rune.Factory {
    [Serializable]
    public class SubEffectInstanceFactory : ISubEffectInstanceFactory {
        
        protected readonly RuneData m_data;

        public SubEffectInstanceFactory(RuneData data) {
            m_data = data;
        }

        public ISubEffect Create() {
            var context = new BulletContext();
            context.SetElements(m_data.Sub.Context);
            
            var result = new SubEffectInstance(
                new RuneCastCountModule(m_data.Sub.Amount),
                new List<IEffect>(m_data.Sub.CastEffect),
                m_data.Sub.OnPreCast,
                m_data.Sub.OnPostCast,
                context
                );
            
            return result;
        }
    }
}