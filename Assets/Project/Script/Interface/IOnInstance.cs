namespace Project.Script.Interface {
    /// <summary>
    /// Prefabとしてインスタンスされた際に実況する処理があるクラスに対して約束するインターフェース
    /// </summary>
    public interface IOnInstance {
        public void OnInstance();
    }
    /// <summary>
    /// Prefabとしてインスタンスされた際に実行される処理があるクラスに対して約束するインターフェース
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IOnInstance<T> {
        public void OnInstance(T t);
    }
}