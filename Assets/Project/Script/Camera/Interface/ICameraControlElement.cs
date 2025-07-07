using UnityEngine;
using VContainer;

namespace Teiwas.Script.Camera.Interface {
    /// <summary>
    /// カメラの位置か角度の制御に関わるインターフェースに対して継承させるインターフェース
    /// </summary>
    public interface ICameraControlElement {
        
        /// <summary>
        /// カメラの制御にかかる機能の演算を開始する
        /// </summary>
        /// <param name="resolver"></param>
        /// <param name="camera"></param>
        public void ControlStart(IObjectResolver resolver, GameObject camera);
        
    }
}