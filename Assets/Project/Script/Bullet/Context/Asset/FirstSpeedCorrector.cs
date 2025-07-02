using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Bullet.Context.Intetface;
using UnityCommonModule.Correction.Interface;
using UnityEngine;

namespace Teiwas.Script.Bullet.Context.Asset {
    [Serializable]
    public class FirstSpeedCorrector : IBulletContextElement {
        
        [OdinSerialize, LabelText("初速にかける補正")]
        protected List<ICorrection> corrections = new List<ICorrection>();
        
        public List<ICorrection> Corrections => corrections;

        public void AddElement(IBulletContextElement element) {
            if (element is FirstSpeedCorrector e) {
                if (e.Corrections.Count == 0 || e.Corrections == null) {
                    Debug.LogError($"与えられたContextにはFistSpeedCorrectorの定義がありましたが、それはそれとして補正値のリストが空でした");
                    return;
                }
                
                foreach (var correction in e.Corrections) {
                    corrections.Add(correction);
                }
            }
            else {
                Debug.Log("与えられたContextにはFistSpeedCorrectorの定義が存在しませんでした");
            }
        }
    }
}