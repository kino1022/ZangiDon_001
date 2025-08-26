using System;
using VContainer.Unity;

namespace Teiwas.Script.Spell.Manager.Container.Interface {
    public interface ISelectSpellContainer : IStartable , IDisposable {
        
        /// <summary>
        /// 他のISpellManagerに対してMainSpellを送信できるかどうか
        /// </summary>
        bool IsMainSendable { get; }
        
        /// <summary>
        /// 他のISpellManagerに対してSubSpellを送信できるかどうか
        /// </summary>
        bool IsSubSendable { get; }
        
    }
}