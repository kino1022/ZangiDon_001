using System;

namespace Teiwas.Script.Interface {
    /// <summary>
    /// データを受信するクラスに対して約束するインターフェース
    /// </summary>
    /// <typeparam name="T">送信するデータの型</typeparam>
    public interface IReceiver<T> {
        
        public void Receive(T data);
        
        public Action<T> ReceiveEvent { get; set; }
    }
}