using System;
using System.Collections.Generic;
using Project.Script.Asset.Bullet.Context.Interface;
using Teiwas.Script.Bullet.Context.Intetface;
using UnityCommonModule.Correction.Interface;
using UnityEngine;

namespace Project.Script.Asset.Bullet.Context {
    [Serializable]
    public class DamageCorrectionContext : IBulletContextElement {
        
        protected List<ICorrection> m_corrections;
        
        public List<ICorrection> Corrections => m_corrections;

        public void AddElement(IBulletContextElement element) {
            
            if (element is IDamageCorrectionContext dam) {
                foreach (var correction in dam.Corrections) {
                    m_corrections.Add(correction);
                }
            }
            else {
                Debug.LogError($"別種のIBulletContextElement{element.GetType()}を受け取りました、処理を中断します");
                return;
            }
            
        }
    }
}