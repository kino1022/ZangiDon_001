using System;
using System.Collections.Generic;
using Teiwas.Script.Damage.Interface;
using Teiwas.Script.Damage.Tag.Interface;
using UnityEngine;

namespace Teiwas.Script.Damage {
    [Serializable]
    public class Damage : IDamageWithTag {

        protected int m_value = 0;
        
        public int Value => m_value;

        protected List<IDamageTag> m_tags = new List<IDamageTag>();
        
        public List<IDamageTag> Tags => m_tags;

        public Damage(int value, List<IDamageTag> tags) {
            m_value = value;

            if (tags.Count is not 0) {
                InjectionDamageTags(tags);
            }
        }

        public bool AddTag(IDamageTag tag) {
            //タグがnullだった場合の分岐処理
            if (tag is null) {
                throw new ArgumentNullException(nameof(tag));
            }
            
            m_tags.Add(tag);
            return true;
        }

        public bool RemoveTag(IDamageTag tag) {
            
            if (tag is null) {
                throw new ArgumentNullException(nameof(tag));
            }
            
            var target = m_tags.Find(x => x == tag);

            if (target is null) {
                Debug.LogError($"{GetType().Name}に{tag.GetType().Name}の定義が存在しませんでした");
                return false;
            }
            
            m_tags.Remove(tag);
            return true;
        }
        
        /// <summary>
        /// タグをリストから注入する処理
        /// </summary>
        /// <param name="tags"></param>
        /// <exception cref="ArgumentNullException"></exception>
        protected void InjectionDamageTags(List<IDamageTag> tags) {
            
            if (tags is null) {
                throw new ArgumentNullException(nameof(tags));
            }

            if (tags.Count is not 0) {
                foreach (var tag in tags) {
                    //tagがnullだった時の分岐処理
                    if (tag is null) {
                        Debug.Log($"{GetType().Name}の初期化に与えられた");
                        continue;
                    }
                    var success = AddTag(tag);
                    //注入に失敗した際の分岐処理
                    if (success is false) {
                        Debug.LogError($"{GetType().Name}に対する{tag.GetType().Name}の注入がなんらかの原因で失敗しました");
                        continue;
                    }
                }
            }
        }
    }
}