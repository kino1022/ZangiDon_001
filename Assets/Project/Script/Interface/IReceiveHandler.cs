using System;

namespace Project.Script.Interface {
    /// <summary>
    /// 情報を受け取った際に通知するクラスに対して与えられるインターフェース
    /// </summary>
    /// <typeparam name="T">情報の型</typeparam>
    public interface IReceiveHandler<T> {
        
        public Action<T> ReceiveEvent { get; set; }
    }
}