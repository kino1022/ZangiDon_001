using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Teiwas.Script.Bullet.Context.Intetface;
using UnityCommonModule.Correction.Interface;

namespace Teiwas.Script.Bullet.Context.Asset {
    [Serializable]
    public class FirstSpeedCorrector : IBulletContextElement {
        
        [OdinSerialize, LabelText("初速にかける補正")]
        protected List<ICorrection> corrections = new List<ICorrection>();
        
        public List<ICorrection> Corrections;

        public void AddElement(IBulletContextElement element) {
            
        }
    }
}