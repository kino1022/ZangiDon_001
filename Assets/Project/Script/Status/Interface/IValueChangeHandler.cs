using System;

namespace Project.Script.Status.Interface {
    
    public interface IValueChangeHandler<T> {
        
        public Action<T> ValueChangeEvent { get; set; }
    }
}