using Project.Script.Asset.Status.Health;
using VContainer;
using R3;
using UnityEngine;

namespace Project.Script.UIControl.PlayerHUD.HealthBar {
    
    public class PlayerHealthBarPresenter {

        protected MaxHealth m_max;

        protected Health m_current;
        
        protected PlayerHealthView m_view;

        public PlayerHealthBarPresenter(MaxHealth max,Health current,PlayerHealthView view) {
            m_max = max;
            m_current = current;
            m_view = view;
            
            RegisterObserve();
        }


        protected void RegisterObserve() {
            Observable.EveryValueChanged(m_current, x => x.GetValue())
                .Subscribe(newValue => {
                    Debug.Log("現在HPの変化を観測したため、Viewのメソッドを呼び出しました");
                    m_view.OnCurrentValueChanged(newValue);
                })
                .Dispose();
            
            Observable.EveryValueChanged(m_max, x => x.GetValue())
                .Subscribe(newValue => {
                    Debug.Log("最大HPの変化を観測したため、Viewのメソッドを呼び出しました");
                    m_view.OnMaxValueChanged(newValue);
                })
                .Dispose();
        }
        
    }
}