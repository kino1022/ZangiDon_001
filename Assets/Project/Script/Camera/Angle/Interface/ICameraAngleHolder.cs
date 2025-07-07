
using Teiwas.Script.Camera.Interface;
using UnityEngine;

namespace Teiwas.Script.Camera.Angle.Interface {
    public interface ICameraAngleHolder : ICameraControlElement {
        public Quaternion Angle { get; }
    }
}