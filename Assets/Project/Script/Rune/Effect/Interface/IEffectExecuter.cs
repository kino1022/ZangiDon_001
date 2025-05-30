namespace Project.Script.Rune.Effect.Interface {
    /// <summary>
    /// 対象に対して何かしらの効果を実行するクラスに対して約束するインターフェース
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEffectExecutor<T> {
        public void ExecuteEffect(T target);
    }
}