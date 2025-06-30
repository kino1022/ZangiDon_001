using System;
using System.Collections.Generic;
using Sirenix.Serialization;
using Teiwas.Script.Bullet.Context.Intetface;
using UnityCommonModule.Correction.Interface;

namespace Teiwas.Script.Bullet.Context.Asset {
    [Serializable]
    public class AccelerationCorrector : IBulletContextElement {
        [OdinSerialize]
        protected List<ICorrection> m_corrections = new List<ICorrection>();
        
        public List<ICorrection> Corrections;
        
        public void AddElement(IBulletContextElement element) {
            
        }
    }
}