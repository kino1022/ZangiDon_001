using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using R3;
using Teiwas.Script.Bullet.Context.Intetface;

namespace Teiwas.Script.Bullet.Context.Helper {
    public static class BulletContextHelper {
        public static BulletContext AddContext(IBulletContext root, in IBulletContext plus) {
            var result = new BulletContext();

            var elements = CreateElementsList(root, plus);

            result.SetElements(elements);

            return result;
        }

        public static List<IBulletContextElement> CreateElementsList(in IBulletContext x, in IBulletContext y) {
            var result = new List<IBulletContextElement>();

            result.AddRange(x.Elements);

            foreach(var item in y.Elements) {
                //itemと同種の物があるかどうか
                if(result.Any(x => x.GetType() == item.GetType())) {
                    UnityEngine.Debug.Log($"{x.GetType()}に{item.GetType()}が存在した為、要素を統合します");
                    var target = result.FirstOrDefault(x => x.GetType() == item.GetType());
                    target?.AddElement(item);
                }
                else {
                    UnityEngine.Debug.Log($"{x.GetType()}に{item.GetType()}が存在しなかった為、リストに追加します");
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
