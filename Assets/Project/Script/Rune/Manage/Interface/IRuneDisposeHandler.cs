using System;

namespace Project.Script.Rune.Manage.Interface { 
    /// <summary>
    /// 何らかの要因で管理しているルーンが無効化される際に発火されるイベントをもつクラスに対して約束するインターフェース
    /// </summary>
    public interface IRuneDisposeHandler {
        /// <summary>
        /// ルーンが無効化される際に発火されるイベント
        /// </summary>
        public Action RuneDisposeEvent { get; set; }
    }
}