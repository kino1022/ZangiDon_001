using System;
using System.Linq;
using ObservableCollections;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Bullet.Context.Intetface;
using UnityEngine;

namespace Teiwas.Script.Bullet.Context {
    /// <summary>
    /// 生成物に対する補正などの修飾内容を示すクラス
    /// </summary>
    [Serializable]
    public class BulletContext : IBulletContext {

        [OdinSerialize, LabelText("適用する要素")] 
        protected ObservableList<IBulletContextElement> m_elements;

        public IReadOnlyObservableList<IBulletContextElement> Elements => m_elements;

        public void Add(IBulletContext context) {

            if (context.Elements.Count == 0 || context.Elements == null) {
                Debug.Log("加算対象のContext内にElementが存在しませんでした");
                return;
            }
            
            foreach (var e in context.Elements) {
                
                var element = m_elements.FirstOrDefault(x => x.GetType() == e.GetType());
                
                //リスト内に型が一致するElementがなかった場合
                if (element == null) {
                    m_elements.Add(e);
                    continue;
                }
                //すでに型が一致するものが存在した場合
                else {
                    element.AddElement(e);
                }
                
            }
            
            Debug.Log("ContextElementの加算処理が終了しました");
        }
    }
}