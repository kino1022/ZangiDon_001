using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

namespace Project.Script.Utility {
    public static class ComponentsUtility {

        public static T GetComponentFromWhole<T>(GameObject obj)  {
            var component = obj.GetComponent<T>();

            if (component == null) {
                Debug.Log($"{obj.name}から{typeof(T)}が取得できなかったため、子からの取得を行います");
                component = obj.GetComponentInChildren<T>();
                if (component == null) {
                    Debug.Log($"子からも{typeof(T)}が取得できなかったため、親からの取得を行います");
                    component = obj.GetComponentInParent<T>();

                    if (component == null) {
                        Debug.LogError($"親からも{typeof(T)}が取得できませんでした。設定を見直してください");
                    }
                }
            }
            return component;
        }

        public static List<T> GetComponentsFromWhole<T>(GameObject obj) {
            var parent = obj.transform.root.gameObject;
            var components = parent.GetComponentsInChildren<T>().ToList();

            if (components.Count == 0) {
                Debug.LogError($"{parent.name}から{typeof(T)}を継承しているオブジェクトが見つかりませんでした");
            }
            
            return components;
        }
        
    }
}