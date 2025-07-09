using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ObservableCollections;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Bullet.Context.Helper;
using Teiwas.Script.Bullet.Context.Intetface;
using UnityEngine;
using VContainer.Unity;

namespace Teiwas.Script.Bullet.Context {
    /// <summary>
    /// 生成物に対する補正などの修飾内容を示すクラス
    /// </summary>
    [Serializable]
    public class BulletContext : IBulletContext {

        [OdinSerialize, LabelText("適用する要素")]
        protected List<IBulletContextElement> m_elements = new();

        public List<IBulletContextElement> Elements => m_elements;


        /// <summary>
        /// 引数として渡されたIBulletContextをひとまとまりにして統合する
        /// </summary>
        /// <param name="context"></param>
        public void Add(IBulletContext context) {

            if(context.Elements == null || context.Elements.Count == 0) {
                Debug.Log($"統合対象のContextにはElementが存在しませんでした");
                return;
            }

            m_elements = BulletContextHelper.CreateElementsList(this, context);
        }

        public void SetElements(List<IBulletContextElement> elements) {
            m_elements = new List<IBulletContextElement>(elements);
        }
    }
}
