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
        
        public List<ICorrection> Corrections  => m_corrections;
        
        public void AddElement(IBulletContextElement element) {
            if (element is AccelerationCorrector acce) {
                m_corrections.AddRange(acce.Corrections);
            }
        }
    }
}