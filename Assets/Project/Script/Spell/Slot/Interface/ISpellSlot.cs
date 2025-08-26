using System;
using Teiwas.Script.Spell.Instance.Interface;
using VContainer.Unity;

namespace Teiwas.Script.Spell.Slot.Interface {
    /// <summary>
    ///　ゲーム中に存在する要素としてのスペルを管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface ISpellSlot<Instance> 
        : IStartable, IDisposable , IInitializable where Instance : ISpellInstance {
        
        Instance Spell { get; }
        
        /// <summary>
        /// スロットが空かどうかの真偽値
        /// </summary>
        /// <value></value>
        bool IsEmpty { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        bool SetInstance(ISpellInstance instance);


        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        bool RemoveInstance();
    }
}
