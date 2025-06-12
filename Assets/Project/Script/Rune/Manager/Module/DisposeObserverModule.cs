using System.Collections.Generic;
using R3;
using ObservableCollections;

namespace Project.Script.Rune.Manager.Module {
    public class DisposeObserverModule {
        
        protected List<RuneInstance> m_runelist = new List<RuneInstance>();
        
        protected ObservableList<RuneInstance> m_runes = new ObservableList<RuneInstance>();

        public DisposeObserverModule(ref List<RuneInstance> runes) {
            
            m_runes.AddRange(runes);
            
            m_runes
                .ObserveAdd()
                .Subscribe( x => OnAdd(x) )
                .Dispose();

            m_runes
                .ObserveRemove()
                .Subscribe( x => OnRemove(x))
                .Dispose();
            
            m_runes
                .ObserveReplace()
                .Subscribe( x => OnReplace(x))
                .Dispose();
            
        }

        public void Dispose() {
            
        }


        protected virtual void OnAdd(CollectionAddEvent<RuneInstance> x) {
            
            Observable
                .EveryValueChanged(x.Value, value => value.GetIsActive() == false)
                .Subscribe(value => {
                    m_runelist.Remove(x.Value);
                })
                .Dispose();
        }
        
        protected virtual void OnRemove (CollectionRemoveEvent<RuneInstance> x) {}

        protected virtual void OnReplace (CollectionReplaceEvent<RuneInstance> x) {}
    }
}