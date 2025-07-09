using VContainer;
using R3;
using Teiwas.Script.Asset.Status.Health.Interface;
using UnityEngine;
using Teiwas.Script.UIControl.PlayerHUD.HealthBar.Interface;

namespace Teiwas.Script.UIControl.PlayerHUD.HealthBar {

    public class PlayerHealthBarPresenter : IPlayerHealthBarPresenter{

        protected IMaxHealth m_max;

        protected IHealth m_current;

        protected PlayerHealthView m_view;

        protected CompositeDisposable m_disposable = new CompositeDisposable();

        [Inject]
        public PlayerHealthBarPresenter(IMaxHealth max, IHealth current, PlayerHealthView view) {
            m_max = max;
            m_current = current;
            m_view = view;

            RegisterObserve();
        }

        public void Dispose() {
            m_disposable.Dispose();
        }


        protected void RegisterObserve() {
            RegisterMaxHealth();
            RegisterHealth();

            m_view.OnStateChange(OnStateChanged());
        }

        protected void RegisterMaxHealth() {
            Debug.Log($"{GetType()}の{m_max.GetType()}に対する値変化の購読処理を開始します");
            Observable
                .EveryValueChanged(m_max, x => x.Get())
                .Subscribe( x => {
                    Debug.Log($"{m_max.GetType()}の値の変化を検知しました");
                    m_view.OnStateChange(OnStateChanged());
                })
                .AddTo(m_disposable);
        }

        protected void RegisterHealth() {
            Debug.Log($"{GetType()}の{m_current.GetType()}に対する値変化の購読処理を開始します");
            Observable
                .EveryValueChanged(m_current, x => x.Get())
                .Subscribe( x => {
                    Debug.Log($"{m_current.GetType()}の値の変化を検知しました");
                    m_view.OnStateChange(OnStateChanged());
                })
                .AddTo(m_disposable);
        }

        protected virtual HeatlhState OnStateChanged() {
            return new HeatlhState(CalculateRatio(), m_max.Get(), m_current.Get());
        }

        protected float CalculateRatio() {
            return (m_max.Get() - m_current.Get()) / m_max.Get();
        }

    }
}
