using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Damage.Interface;
using Teiwas.Script.Damage.Processor.Interface;
using Teiwas.Script.Damage.Processor.Pointer.Interface;
using UnityEngine;
using VContainer;

namespace Teiwas.Script.Damage.Processor {
    [Serializable]
    public class DamageProcessor : IDamageProcessor {

        protected IDamageEntryPoint m_entry;

        protected IDamageEndPoint m_end;
        
        protected IObjectResolver m_resolver;

        [OdinSerialize, LabelText("ダメージ計算にかかる要素")]
        protected List<IDamageProcessElement> m_elements = new();

        [Inject]
        public DamageProcessor(IObjectResolver resolver) {
            m_resolver = resolver
                         ?? throw new ArgumentNullException($"{GetType().Name}の初期化の際にIObjectResolverを取得できませんでした");
        }

        public void Start() {
            
            m_entry = m_resolver.Resolve<IDamageEntryPoint>() 
                      ?? throw new NullReferenceException($"{GetType().Name}で{typeof(IDamageEntryPoint).Name}が取得できませんでした");

            m_end = m_resolver.Resolve<IDamageEndPoint>() 
                    ?? throw new NullReferenceException($"{GetType().Name}で{typeof(IDamageEndPoint).Name}が取得できませんでした");
            
        }

        public void Dispose() {
            
        }

        public bool Processing(IDamage damage) {
            
            var success = m_entry.Process(damage);

            if (success is false) {
                Debug.LogError($"{GetType().Name}のダメージ計算のエントリーの計算処理に失敗しました");
                return false;
            }

            if (m_elements.Count is not 0) {
                foreach (var element in m_elements) {
                    if (element is null) {
                        Debug.LogError($"{GetType().Name}のダメージ計算にかかる要素がnullでした");
                        continue;
                    }
                    element.Process(damage);
                }
            }
            
            return m_end.Process(damage);
        }
        
    }
}