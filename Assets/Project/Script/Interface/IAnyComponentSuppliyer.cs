using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Script.Interface {
    public interface IAnyComponentSupplier {
        public T GetAnyComponent<T>() where T : MonoBehaviour;
    }
}