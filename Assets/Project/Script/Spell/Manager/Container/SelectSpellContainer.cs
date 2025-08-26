using System;
using MessagePipe;
using R3;
using Teiwas.Script.Spell.Instance.Main.Interface;
using Teiwas.Script.Spell.Instance.Sub.Insterface;
using Teiwas.Script.Spell.Manager.Container.Interface;
using Teiwas.Script.Spell.Manager.EventBus;
using Teiwas.Script.Spell.Manager.Main.Interface;
using Teiwas.Script.Spell.Manager.Sub;
using VContainer;

namespace Teiwas.Script.Spell.Manager.Container {
    /// <summary>
    /// 選択されたルーンの送信先を管理するクラス
    /// </summary>
    [Serializable]
    public class SelectSpellContainer : ISelectSpellContainer {

        protected IMainSpellManager m_main;
        
        protected ISubSpellManager m_sub;
        
        protected IObjectResolver m_resolver;
        
        protected ISubscriber<OnSelectSpellEventBus> m_subscriber;
        
        protected CompositeDisposable m_disposable;

        public bool IsMainSendable => QueryMainSendable();
        
        public bool IsSubSendable => QuerySubSendable();

        [Inject]
        public SelectSpellContainer(IObjectResolver resolver) {
            m_resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        public void Start() {
            m_main = m_resolver.Resolve<IMainSpellManager>() 
                     ?? throw new NullReferenceException();
            m_sub = m_resolver.Resolve<ISubSpellManager>()
                     ?? throw new NullReferenceException();
            m_subscriber = m_resolver.Resolve<ISubscriber<OnSelectSpellEventBus>>() 
                           ?? throw new NullReferenceException();
            m_disposable = new CompositeDisposable();

            m_subscriber.Subscribe(OnSelected).AddTo(m_disposable);
        }

        public void Dispose() {
            m_disposable.Dispose();
        }

        protected void OnSelected(OnSelectSpellEventBus eventBus) {
            //選択されたルーンがメインだった場合の分岐処理
            if (eventBus.Spell is IMainSpellInstance main) {
                
            }
            //選択されたルーンがサブだった場合の分岐処理
            if (eventBus.Spell is ISubSpellInstance sub) {
                
            }
        }

        protected bool QueryMainSendable() => !m_main.IsFull;
        
        protected bool QuerySubSendable() => !m_sub.IsFull;
    }
}