namespace Teiwas.Script.Interface {
    /// <summary>
    /// データを送信するクラスに対して約束するインターフェース
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public interface ISender <T,T2> where T2 : IReceiver<T> {
        
        /// <summary>
        /// 指定したreceiverに対してデータTを送信する
        /// </summary>
        /// <param name="data">送信するデータ</param>
        /// <param name="receiver">受信側インスタンス</param>
        public void Send(T data,T2 receiver);
    }
    
    /// <summary>
    /// データを送信するクラスに対して約束するインターフェース
    /// </summary>
    /// <typeparam name="T">送信するデータの型</typeparam>
    public interface ISender<T> {
        
        /// <summary>
        /// データを送信するメソッド
        /// </summary>
        /// <param name="data"></param>
        public void Send(T data);
    }
}