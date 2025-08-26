using System.Collections.Generic;
using Teiwas.Script.Damage.Factory.Interface;
using Teiwas.Script.Damage.Interface;
using Teiwas.Script.Damage.Tag.Interface;
using Unity.VisualScripting;

namespace Teiwas.Script.Damage.Factory {
    /// <summary>
    /// ダメージのインスタンスを行うクラス
    /// </summary>
    public class DamageInstanceFactory : IDamageFactory<Damage> {

        protected int m_value = 0;
        
        public int Value  {
            get { return m_value; }
            set {
                m_value = value;
            }
        }

        protected List<IDamageTag> m_tags = new List<IDamageTag>();

        public List<IDamageTag> Tags => m_tags;

        public DamageInstanceFactory() {
            
        }

        public void Dispose() {
            throw new System.NotImplementedException();
        }

        public Damage Create() {
            var product = new Damage(Value, Tags);

            return product;
        }
    }
}