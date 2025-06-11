using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Project.Script.Rune.Manager.Factory {
    [Serializable]
    public abstract class ARuneManagerFactory<T> where T : ARuneManager {

        [OdinSerialize, LabelText("ルーンリストの長さ")]
        protected int m_amount;
        
        public abstract T Create();
    }
}