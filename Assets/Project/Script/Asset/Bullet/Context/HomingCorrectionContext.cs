using System;
using Teiwas.Script.Bullet.Context.Intetface;
using UnityEngine;

namespace Project.Script.Asset.Bullet.Context {
    [Serializable]
    public class HomingCorrectionContext : IBulletContextElement {
        
        
        
        public void AddElement(IBulletContextElement element) {
            if (element is HomingCorrectionContext hom) {
                
            }
            else {
                Debug.LogError($"別種のIBulletContextElement{element.GetType()}を受け取りました、処理を中断します");
                return;
            }
        }
    }
}