namespace Teiwas.Script.Interface {
    /// <summary>
    /// FixedUpdate時に処理を行うクラスに対して約束するインターフェース
    /// </summary>
    public interface IOnFixedUpdate {
        public void OnFixedUpdate();
    }

    public interface IOnFixedUpdate<T> {
        public void OnFixedUpdate(T t);
    }
}