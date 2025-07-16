namespace Teiwas.Script.Motion.State.Context.Interface {
    /// <summary>
    /// アニメーションのそのフレームで落下可能かどうかのデータを保持するクラスに対して約束するインターフェース
    /// </summary>
    public interface IInMotionFreeFallContext {

        public void Update(int frame);

        /// <summary>
        /// 現在フレームで落下が有効化どうかを取得する
        /// </summary>
        /// <param name="currentFrame"></param>
        /// <returns></returns>
        public bool Fallable { get; }

    }
}
