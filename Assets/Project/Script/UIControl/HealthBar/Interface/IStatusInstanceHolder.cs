using UnityCommonModule.Status;

namespace Project.Script.UIControl.HealthBar.Interface {
    public interface IStatusInstanceHolder {
        
        public AStatus<int> Max { get; }
        
        public AStatus<int> Current { get; }
        
    }
}