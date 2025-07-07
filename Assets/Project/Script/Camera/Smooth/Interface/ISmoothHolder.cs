using Teiwas.Script.Camera.Interface;

namespace Teiwas.Script.Camera.Smooth.Interface {
    public interface ISmoothHolder : ICameraControlElement {
        /// <summary>
        /// 管理しているスムーズさ
        /// </summary>
        public float Smooth { get; }
    }
}