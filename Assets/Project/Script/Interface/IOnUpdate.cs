namespace Teiwas.Script.Interface {
    /// <summary>
    /// Update時の処理を持つ非MonoBehaviourクラスに約束するインターフェース
    /// </summary>
    public interface IOnUpdate {
        public void OnUpdate();
    }
    
    /// <summary>
    /// Update時の処理を持つ非MonoBehaviourクラスに約束するインターフェース(ジェネリクス)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IOnUpdate<T> {
        public void OnUpdate(T arg);
    }
}