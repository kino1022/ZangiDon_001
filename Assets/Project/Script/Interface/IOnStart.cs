namespace Project.Script.Interface {
    ///　Start時の処理を持つ非Monobehaviourクラスに対して約束するインターフェース
    public interface IOnStart {
        public void OnStart();
    }
    
    /// Start時の処理を持つ非Monobehaviourクラスに対して約束するインターフェース(ジェネリクス)
    public interface IOnStart<T> {
        public void OnStart(T arg);
    }
}