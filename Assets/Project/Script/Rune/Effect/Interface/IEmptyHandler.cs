using System;

namespace Project.Script.Rune.Effect.Interface {
    /// <summary>
    /// 使用回数が0になった事を通知するクラスに約束するインターフェース
    /// </summary>
    public interface IEmptyEffectHandler {
        
        public Action<ARuneEffect> EmptyEffectEvent { get; set; } 
    }
}