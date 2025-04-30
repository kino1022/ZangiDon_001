namespace Project.Script.Interface {
    /// <summary>
    /// Destroy時に呼び出される処理を持つ非MonoBehaviourクラスに約束するインターフェース
    /// </summary>
    public class IOnDestroy {
        public void OnDestroy() {}
    }
    /// <summary>
    /// Destroy時に呼び出される処理を持つ非MonoBehaviourクラスに約束するインターフェース(ジェネリクス)
    /// </summary>
    public interface IOnDestroy<T> {
        public void OnDestroy(T arg);
    }
}