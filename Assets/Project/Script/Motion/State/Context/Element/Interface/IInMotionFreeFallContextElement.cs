namespace Teiwas.Script.Motion.State.Context.Element.Interface {
    public interface IInMotionFreeFallContextElement {
        /// <summary>
        /// 現在フレームで落下可能か示す
        /// </summary>
        /// <param name="currentFrame"></param>
        /// <returns></returns>
        public bool Fallable(int currentFrame);
    }
}
