using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Spell.Data.Interface;
using Teiwas.Script.Spell.Factory.Interface;
using Teiwas.Script.Spell.Instance.Interface;

namespace Teiwas.Script.Spell.Factory {
    public abstract class ASpellFactory<D,I> : ISpellFactory<D,I> where D : ISpellData where I : ISpellInstance {

        [Title("設定")] [OdinSerialize, LabelText("使用するデータ")]
        protected List<D> m_datas = new();

        [Title("ランタイム")] [OdinSerialize, LabelText("<UNK>"), ReadOnly]
        protected List<D> m_runtimeDatas = new();

        public virtual void Start() {

            m_runtimeDatas.Clear();

            m_runtimeDatas = CreateRunTimeData();

        }

        public virtual void Dispose() {

        }

        public abstract I Create();

        /// <summary>
        /// プレイ中に使用するランタイムデータの生成処理
        /// </summary>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        protected List<D> CreateRunTimeData() {

            if(m_datas.Count is 0) {
                throw new IndexOutOfRangeException($"{GetType().Name}に設定された{nameof(D)}のリストが空でした");
            }

            return new List<D>(m_datas);
        }
    }
}
