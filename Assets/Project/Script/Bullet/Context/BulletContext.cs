using System;
using System.Linq;
using ObservableCollections;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Bullet.Context.Intetface;
using UnityEngine;
using VContainer.Unity;

namespace Teiwas.Script.Bullet.Context {
    /// <summary>
    /// 生成物に対する補正などの修飾内容を示すクラス
    /// </summary>
    [Serializable]
    public class BulletContext : IBulletContext {

        [OdinSerialize, LabelText("適用する要素")] protected ObservableList<IBulletContextElement> m_elements = new();

        public IReadOnlyObservableList<IBulletContextElement> Elements => m_elements;
        
        
        protected void IntegrationElements() {
            foreach (var e in m_elements) {
                //eと同型のElementの抽出処理
                var same = m_elements.Where(x => x.GetType() == e.GetType()).ToList();
                //eそのものの除外処理
                same.Remove(e);

                if (same.Count > 1) {
                    Debug.Log($"同種のContextElementが複数定義されているため、統合処理を開始します");
                    foreach (var element in same) {
                        e.AddElement(element);
                        m_elements.Remove(element);
                    }
                }
            }
        }

        public void Add(IBulletContext context) {

            if (context.Elements == null || context.Elements.Count == 0) {
                Debug.Log($"統合対象のContextにはElementが存在しませんでした");
                return;
            }
            
            foreach (var e in context.Elements) {
                
                if (m_elements?.Any(x => x.GetType() == e.GetType()) == false) {
                    m_elements.Add(e);
                    continue;
                }
                
                var target = m_elements?.FirstOrDefault(x => x.GetType() == e.GetType());
                
                target?.AddElement(e);
                
            }
        }
    }
}